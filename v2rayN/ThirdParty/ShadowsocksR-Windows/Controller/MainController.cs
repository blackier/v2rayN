using Shadowsocks.Controller.Service;
using Shadowsocks.Enums;
using Shadowsocks.Model;
using Shadowsocks.Model.Transfer;
using Shadowsocks.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Forms;

namespace Shadowsocks.Controller
{
    public class MainController
    {
        // controller:
        // handle user actions
        // manipulates UI
        // interacts with low level logic

        private Listener _listener;
        private List<Listener> _portMapListener;

        private readonly ServerTransferTotal _transfer;
        private HttpProxyRunner _httpProxyRunner;
        private bool _stopped;

        public class PathEventArgs : EventArgs
        {
            public string Path;
        }

        #region Event

        public event EventHandler ShowConfigFormEvent;
        public event EventHandler ShowSubscribeWindowEvent;

        public event ErrorEventHandler Errored;

        #endregion

        public MainController()
        {
            _transfer = ServerTransferTotal.Load();
        }

        private void ReportError(Exception e)
        {
            Errored?.Invoke(this, new ErrorEventArgs(e));
        }

        private static int FindFirstMatchServer(Server server, IReadOnlyList<Server> servers)
        {
            for (var i = 0; i < servers.Count; ++i)
            {
                if (server.IsMatchServer(servers[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        private static IEnumerable<Server> MergeConfiguration(Configuration mergeConfig, IReadOnlyList<Server> servers)
        {
            if (servers != null)
            {
                foreach (var server in servers)
                {
                    var i = FindFirstMatchServer(server, mergeConfig.Configs);
                    if (i != -1)
                    {
                        var enable = server.Enable;
                        server.CopyServer(mergeConfig.Configs[i]);
                        server.Enable = enable;
                    }
                }
            }

            return from t in mergeConfig.Configs let j = FindFirstMatchServer(t, servers) where j == -1 select t;
        }

        public void SaveServersConfig(Configuration config, bool reload)
        {
            var missingServers = MergeConfiguration(Global.GuiConfig, config.Configs);
            Global.GuiConfig.CopyFrom(config);
            foreach (var s in missingServers)
            {
                s.Connections.CloseAll();
            }

        }

        public void SaveServersPortMap(Configuration config)
        {
            StopPortMap();
            Global.GuiConfig.PortMap = config.PortMap;
            Global.GuiConfig.FlushPortMapCache();
            LoadPortMap();
        }

        /// <summary>
        /// 选择指定服务器
        /// </summary>
        public void SelectServerIndex(int index)
        {
            Global.GuiConfig.Index = index;
        }

        /// <summary>
        /// 导入服务器链接
        /// </summary>
        public bool AddServerBySsUrl(string ssUrLs, string force_group = null, bool toLast = false)
        {
            try
            {
                var urls = ssUrLs.GetLines().Reverse();
                var i = 0;
                foreach (var url in urls.Select(url => url.Trim('/')).Where(url => url.StartsWith(@"ss://", StringComparison.OrdinalIgnoreCase) || url.StartsWith(@"ssr://", StringComparison.OrdinalIgnoreCase)))
                {
                    ++i;
                    var server = new Server(url, force_group);
                    if (toLast)
                    {
                        Global.GuiConfig.Configs.Add(server);
                    }
                    else
                    {
                        var index = Global.GuiConfig.Index + 1;
                        if (index < 0 || index > Global.GuiConfig.Configs.Count)
                        {
                            index = Global.GuiConfig.Configs.Count;
                        }

                        Global.GuiConfig.Configs.Insert(index, server);
                    }
                }
                if (i > 0)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                Logging.LogUsefulException(e);
                return false;
            }
            return false;
        }

        /// <summary>
        /// 切换系统代理模式
        /// </summary>
        public void ToggleMode(ProxyMode mode)
        {
            Global.GuiConfig.SysProxyMode = mode;
        }

        /// <summary>
        /// 切换代理规则
        /// </summary>
        /// <param name="mode"></param>
        public void ToggleRuleMode(ProxyRuleMode mode)
        {
            Global.GuiConfig.ProxyRuleMode = mode;
        }

        public void ToggleSelectRandom(bool enabled)
        {
            Global.GuiConfig.Random = enabled;
            if (!enabled)
            {
                DisconnectAllConnections(true);
            }
        }

        public void ToggleSameHostForSameTargetRandom(bool enabled)
        {
            Global.GuiConfig.SameHostForSameTarget = enabled;
        }

        public void ToggleSelectAutoCheckUpdate(bool enabled)
        {
            Global.GuiConfig.AutoCheckUpdate = enabled;
        }

        public void ToggleSelectAllowPreRelease(bool enabled)
        {
            Global.GuiConfig.IsPreRelease = enabled;
        }

        private void StopPortMap()
        {
            if (_portMapListener != null)
            {
                foreach (var l in _portMapListener)
                {
                    l.Stop();
                }

                _portMapListener = null;
            }
        }

        private void LoadPortMap()
        {
            _portMapListener = new List<Listener>();
            foreach (var pair in Global.GuiConfig.PortMapCache)
            {
                try
                {
                    var local = new Local(Global.GuiConfig, _transfer);
                    var services = new List<Listener.IService> { local };
                    var listener = new Listener(services);
                    listener.Start(Global.GuiConfig, pair.Key);
                    _portMapListener.Add(listener);
                }
                catch (Exception e)
                {
                    ThrowSocketException(ref e);
                    Logging.LogUsefulException(e);
                    ReportError(e);
                }
            }
        }

        public void Stop()
        {
            if (_stopped)
            {
                return;
            }
            _stopped = true;

            StopPortMap();

            _listener?.Stop();
            _httpProxyRunner?.Stop();
            ServerTransferTotal.Save(_transfer, Global.GuiConfig.Configs);
        }

        public void ClearTransferTotal(string serverId)
        {
            _transfer.Clear(serverId);
            var server = Global.GuiConfig.Configs.Find(s => s.Id == serverId);
        }

        private void ReloadProxyRule()
        {
            HostMap.Reload();
        }

        public void Reload()
        {
            StopPortMap();
            // some logic in configuration updated the config when saving, we need to read it again
            Global.GuiConfig.FlushPortMapCache();
            Logging.SaveToFile = Global.GuiConfig.LogEnable;
            Logging.OpenLogFile();

            ReloadProxyRule();

            _httpProxyRunner ??= new HttpProxyRunner();

            _listener?.Stop();
            _httpProxyRunner.Stop();
            try
            {
                _httpProxyRunner.Start(Global.GuiConfig);

                var local = new Local(Global.GuiConfig, _transfer);
                var services = new List<Listener.IService>
                {
                    local,
                    new HttpPortForwarder(_httpProxyRunner.RunningPort, Global.GuiConfig)
                };
                _listener = new Listener(services);
                _listener.Start(Global.GuiConfig, 0);
            }
            catch (Exception e)
            {
                ThrowSocketException(ref e);
                Logging.LogUsefulException(e);
                ReportError(e);
            }

            LoadPortMap();
        }

        private static void ThrowSocketException(ref Exception e)
        {
            // TODO:translate Microsoft language into human language
            // i.e. An attempt was made to access a socket in a way forbidden by its access permissions => Port already in use
            // https://docs.microsoft.com/zh-cn/dotnet/api/system.net.sockets.socketerror
            if (e is not SocketException se)
            {
                return;
            }

            switch (se.SocketErrorCode)
            {
                case SocketError.AddressAlreadyInUse:
                    {
                        e = new Exception(@"PortInUse{LocalPort}", se);
                        break;
                    }
                case SocketError.AccessDenied:
                    {
                        e = new Exception(@"PortReservedLocalPort", se);
                        break;
                    }
            }
        }


        public void ShowConfigForm(int? index = null)
        {
            ShowConfigFormEvent?.Invoke(index, EventArgs.Empty);
        }

        public void ShowSubscribeWindow()
        {
            ShowSubscribeWindowEvent?.Invoke(default, EventArgs.Empty);
        }

        /// <summary>
        /// Disconnect all connections from the remote host.
        /// </summary>
        public void DisconnectAllConnections(bool checkSwitchAutoCloseAll = false)
        {
            var config = Global.GuiConfig;
            if (checkSwitchAutoCloseAll && !config.CheckSwitchAutoCloseAll)
            {
                Console.WriteLine(@"config.checkSwitchAutoCloseAll:False");
                return;
            }
            foreach (var server in config.Configs)
            {
                server.Connections.CloseAll();
            }
        }

    }
}
