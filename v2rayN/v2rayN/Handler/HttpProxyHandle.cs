using System;
using v2rayN.Mode;

using Shadowsocks.WPF.Services.SystemProxy;

namespace v2rayN.Handler
{
    /// <summary>
    /// 系统代理(http)模式
    /// </summary>
    public enum ListenerType
    {
        noHttpProxy = 0,
        GlobalHttp,
        HttpOpenAndClear,
        HttpOpenOnly
    }
    /// <summary>
    /// 系统代理(http)总处理
    /// 启动privoxy提供http协议
    /// 设置IE系统代理或者PAC模式
    /// </summary>
    class HttpProxyHandle
    {
        private static bool Update(Config config, bool forceDisable)
        {
            ListenerType type = config.listenerType;

            if (forceDisable)
            {
                type = ListenerType.noHttpProxy;
            }

            try
            {
                if (type != ListenerType.noHttpProxy)
                {
                    int port = Global.httpPort;
                    if (port <= 0)
                    {
                        return false;
                    }
                    if (type == ListenerType.GlobalHttp)
                    {
                        WinINet.ProxyGlobal($"{Global.Loopback}:{port}", Global.IEProxyExceptions);
                    }
                    else if (type == ListenerType.HttpOpenAndClear)
                    {
                        WinINet.Reset();
                    }
                    else if (type == ListenerType.HttpOpenOnly)
                    {
                    }
                }
                else
                {
                    WinINet.Reset();
                }
            }
            catch (Exception ex)
            {
                Utils.SaveLog(ex.Message, ex);
            }
            return true;
        }

        /// <summary>
        /// 启用系统代理(http)
        /// </summary>
        /// <param name="config"></param>
        private static void StartHttpAgent(Config config)
        {
            try
            {
                int localPort = config.GetLocalPort(Global.InboundSocks);
                if (localPort > 0)
                {
                    Global.privoxyRunner.Start(config.allowLANConn ? "0.0.0.0" : Global.Loopback, config.GetLocalPort(Global.InboundHttp), Global.Loopback, localPort);
                    if (Global.privoxyRunner.RunningPort > 0)
                    {
                        Global.sysAgent = true;
                        Global.socksPort = localPort;
                        Global.httpPort = Global.privoxyRunner.RunningPort;
                        Global.pacPort = config.GetLocalPort("pac");
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 关闭系统代理
        /// </summary>
        /// <param name="config"></param>
        public static void CloseHttpAgent(Config config)
        {
            try
            {
                if (config.listenerType != ListenerType.HttpOpenOnly)
                {
                    Update(config, true);
                }

                Global.privoxyRunner.Stop();

                Global.sysAgent = false;
                Global.socksPort = 0;
                Global.httpPort = 0;
            }
            catch
            {
            }
        }

        /// <summary>
        /// 重启系统代理(http)
        /// </summary>
        /// <param name="config"></param>
        /// <param name="forced"></param>
        public static void RestartHttpAgent(Config config, bool forced)
        {
            bool isRestart = false;
            if (config.listenerType == ListenerType.noHttpProxy)
            {
                // 关闭http proxy时，直接返回
                return;
            }
            //强制重启或者socks端口变化
            if (forced)
            {
                isRestart = true;
            }
            else
            {
                int localPort = config.GetLocalPort(Global.InboundSocks);
                if (localPort != Global.socksPort)
                {
                    isRestart = true;
                }
            }
            if (isRestart)
            {
                CloseHttpAgent(config);
                StartHttpAgent(config);
            }
            Update(config, false);
        }

        public static string GetPacUrl()
        {
            string pacUrl = $"http://{Global.Loopback}:{Global.pacPort}/pac/?t={ DateTime.Now.ToString("HHmmss")}";
            return pacUrl;
        }
    }
}
