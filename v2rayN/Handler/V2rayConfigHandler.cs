using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using v2rayN.Config;
using v2rayN.Extension;
using V2Ray = Shadowsocks.Interop.V2Ray;
using V2RayConfig = Shadowsocks.Interop.V2Ray.Config;

namespace v2rayN.Handler
{
    /// <summary>
    /// v2ray配置文件处理类
    /// </summary>
    class v2rayConfigHandler
    {
        #region 生成客户端配置

        /// <summary>
        /// 生成v2ray的客户端配置文件
        /// </summary>
        /// <param name="config"></param>
        /// <param name="fileName"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static int GenerateClientConfig(Config.V2RayNConfig config, string fileName, bool blExport, out string msg)
        {
            try
            {
                //检查GUI设置
                if (config == null
                    || config.index < 0
                    || config.vmess.Count <= 0
                    || config.index > config.vmess.Count - 1
                    )
                {
                    msg = Utils.StringsRes.I18N("CheckServerSettings");
                    return -1;
                }

                msg = Utils.StringsRes.I18N("InitialConfiguration");
                if (config.configType() == (int)EConfigType.Custom)
                {
                    return GenerateClientCustomConfig(config, fileName, out msg);
                }

                //转成Json
                var v2rayConfig = V2RayConfig.Default;
                if (v2rayConfig == null)
                {
                    msg = Utils.StringsRes.I18N("FailedGenDefaultConfiguration");
                    return -1;
                }

                //开始修改配置
                SetLog(config, ref v2rayConfig, blExport);

                //本地端口
                SetInbound(config, ref v2rayConfig);

                //路由
                SetRouting(config, ref v2rayConfig);

                //outbound
                SetOutbound(config, ref v2rayConfig);

                //dns
                SetDNS(config, ref v2rayConfig);

                // 统计配置
                SetAPI(config, ref v2rayConfig);

                Utils.ToJsonFile(v2rayConfig, fileName, false, true);

                msg = string.Format(Utils.StringsRes.I18N("SuccessfulConfiguration"), config.getSummary());
            }
            catch (Exception e)
            {
                msg = Utils.StringsRes.I18N("FailedGenDefaultConfiguration");
                Utils.SaveLog(e.Message, e);
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// 日志
        /// </summary>
        /// <param name="config"></param>
        /// <param name="v2rayConfig"></param>
        /// <returns></returns>
        private static int SetLog(Config.V2RayNConfig config, ref V2RayConfig v2rayConfig, bool blExport)
        {
            if (blExport)
            {
                if (config.logEnabled)
                {
                    v2rayConfig.Log.Loglevel = config.loglevel;
                }
                else
                {
                    v2rayConfig.Log.Loglevel = config.loglevel;
                    v2rayConfig.Log.Access = "";
                    v2rayConfig.Log.Error = "";
                }
            }
            else
            {
                if (config.logEnabled)
                {
                    v2rayConfig.Log.Loglevel = config.loglevel;
                    v2rayConfig.Log.Access = Utils.GetPath(v2rayConfig.Log.Access);
                    v2rayConfig.Log.Error = Utils.GetPath(v2rayConfig.Log.Error);
                }
                else
                {
                    v2rayConfig.Log.Loglevel = config.loglevel;
                    v2rayConfig.Log.Access = "";
                    v2rayConfig.Log.Error = "";
                }
            }
            return 0;
        }

        /// <summary>
        /// 本地端口
        /// </summary>
        /// <param name="config"></param>
        /// <param name="v2rayConfig"></param>
        /// <returns></returns>
        private static int SetInbound(Config.V2RayNConfig config, ref V2RayConfig v2rayConfig)
        {
            // socks proxy
            var socksInbound = V2Ray.InboundObject.DefaultLocalSocks;
            socksInbound.Tag = "socksProxy";
            // 端口
            socksInbound.Port = config.inbound[0].localPort;
            if (config.allowLANConn)
                socksInbound.Listen = "0.0.0.0";
            else
                socksInbound.Listen = Global.Loopback;
            // 流量探测
            socksInbound.Sniffing.Enabled = config.inbound[0].sniffingEnabled;

            // http proxy
            var httpInbound = V2Ray.InboundObject.DefaultLocalHttp;
            httpInbound.Listen = socksInbound.Listen;
            httpInbound.Tag = "httpProxy";
            httpInbound.Port = config.inbound[0].localPort + 1;
            httpInbound.Sniffing.Enabled = config.inbound[0].sniffingEnabled;

            v2rayConfig.Inbounds.Add(socksInbound);
            v2rayConfig.Inbounds.Add(httpInbound);
            return 0;
        }

        /// <summary>
        /// 路由
        /// </summary>
        /// <param name="config"></param>
        /// <param name="v2rayConfig"></param>
        /// <returns></returns>
        private static int SetRouting(Config.V2RayNConfig config, ref V2RayConfig v2rayConfig)
        {
            if (v2rayConfig.Routing != null
              && v2rayConfig.Routing.Rules != null)
            {
                v2rayConfig.Routing.DomainStrategy = config.domainStrategy;

                //自定义
                //需代理
                routingUserRule(config.useragent, Global.agentTag, ref v2rayConfig);
                //直连
                routingUserRule(config.userdirect, Global.directTag, ref v2rayConfig);
                //阻止
                routingUserRule(config.userblock, Global.blockTag, ref v2rayConfig);
            }
            return 0;
        }
        private static int routingUserRule(List<string> userRule, string tag, ref V2RayConfig v2rayConfig)
        {
            if (userRule != null && userRule.Count > 0)
            {
                var ipRule = new V2Ray.Routing.RuleObject
                {
                    Type = "field",
                    OutboundTag = tag,
                    Ip = new List<string>()
                };
                var domainRule = new V2Ray.Routing.RuleObject
                {
                    Type = "field",
                    OutboundTag = tag,
                    Domain = new List<string>()
                };

                foreach (string u in userRule)
                {
                    string url = u.TrimEx();
                    if (Utils.IsNullOrEmpty(url))
                    {
                        continue;
                    }
                    if (Utils.IsIP(url) || url.StartsWith("geoip:"))
                    {
                        ipRule.Ip.Add(url);
                    }
                    else if (Utils.IsDomain(url)
                        || url.StartsWith("geosite:")
                        || url.StartsWith("regexp:")
                        || url.StartsWith("domain:")
                        || url.StartsWith("full:"))
                    {
                        domainRule.Domain.Add(url);
                    }
                }
                if (ipRule.Ip.Count > 0)
                {
                    v2rayConfig.Routing.Rules.Add(ipRule);
                }
                if (domainRule.Domain.Count > 0)
                {
                    v2rayConfig.Routing.Rules.Add(domainRule);
                }
            }
            return 0;
        }

        /// <summary>
        /// vmess协议服务器配置
        /// </summary>
        /// <param name="config"></param>
        /// <param name="v2rayConfig"></param>
        /// <returns></returns>
        private static int SetOutbound(Config.V2RayNConfig config, ref V2RayConfig v2rayConfig)
        {
            if (config.configType() == (int)EConfigType.Vmess)
            {
                var outbound = V2Ray.OutboundObject.GetVMess(Global.agentTag, config.address(), config.port(), config.id());

                var settings = (V2Ray.Protocols.VMess.OutboundConfigurationObject)outbound.Settings;
                settings.Vnext[0].Users[0].AlterId = config.alterId();
                settings.Vnext[0].Users[0].Email = Global.userEMail;
                settings.Vnext[0].Users[0].Security = config.security();

                //Mux
                outbound.Mux = new();
                outbound.Mux.Enabled = config.muxEnabled;
                outbound.Mux.Concurrency = config.muxEnabled ? 8 : -1;

                //远程服务器底层传输配置
                var streamSettings = new V2Ray.Transport.StreamSettingsObject();
                boundStreamSettings(config, ref streamSettings);
                outbound.StreamSettings = streamSettings;

                v2rayConfig.Outbounds.Add(outbound);

            }
            else if (config.configType() == (int)EConfigType.Shadowsocks)
            {
                var outbound = V2Ray.OutboundObject.GetShadowsocks(Global.agentTag);
                var settings = (V2Ray.Protocols.Shadowsocks.OutboundConfigurationObject)outbound.Settings;

                //远程服务器地址和端口
                settings.Servers[0].Address = config.address();
                settings.Servers[0].Port = config.port();
                settings.Servers[0].Password = config.id();
                settings.Servers[0].Method = config.security();

                //Mux
                outbound.Mux = new();
                outbound.Mux.Enabled = config.muxEnabled;
                outbound.Mux.Concurrency = config.muxEnabled ? 8 : -1;

                v2rayConfig.Outbounds.Add(outbound);

            }
            else if (config.configType() == (int)EConfigType.Socks)
            {
                var outbound = V2Ray.OutboundObject.GetSocks(Global.agentTag, new DnsEndPoint(config.address(), config.port()));
                var settings = (V2Ray.Protocols.Socks.OutboundConfigurationObject)outbound.Settings;

                if (!Utils.IsNullOrEmpty(config.security())
                    && !Utils.IsNullOrEmpty(config.id()))
                {
                    settings.Servers[0].Users.Add(new() { User = config.security(), Pass = config.id(), Level = 1 });
                }

                //Mux
                outbound.Mux = new();
                outbound.Mux.Enabled = config.muxEnabled;
                outbound.Mux.Concurrency = config.muxEnabled ? 8 : -1;

                v2rayConfig.Outbounds.Add(outbound);
            }
            else if (config.configType() == (int)EConfigType.VLESS)
            {
                var outbound = V2Ray.OutboundObject.GetVLESS(Global.agentTag, config.address(), config.port(), config.id());

                var settings = (V2Ray.Protocols.VLESS.OutboundConfigurationObject)outbound.Settings;

                //远程服务器用户ID
                settings.Vnext[0].Users[0].Email = Global.userEMail;
                settings.Vnext[0].Users[0].Encryption = config.security();

                //Mux
                outbound.Mux = new();
                outbound.Mux.Enabled = config.muxEnabled;
                outbound.Mux.Concurrency = config.muxEnabled ? 8 : -1;

                //远程服务器底层传输配置
                var streamSettings = new V2Ray.Transport.StreamSettingsObject();
                boundStreamSettings(config, ref streamSettings);
                outbound.StreamSettings = streamSettings;

                v2rayConfig.Outbounds.Add(outbound);
            }
            else if (config.configType() == (int)EConfigType.Trojan)
            {
                var outbound = V2Ray.OutboundObject.GetTrojan(Global.agentTag, config.address(), config.port(), config.id());

                //Mux
                outbound.Mux = new();
                outbound.Mux.Enabled = config.muxEnabled;
                outbound.Mux.Concurrency = config.muxEnabled ? 8 : -1;

                //远程服务器底层传输配置
                var streamSettings = new V2Ray.Transport.StreamSettingsObject();
                boundStreamSettings(config, ref streamSettings);
                outbound.StreamSettings = streamSettings;

                v2rayConfig.Outbounds.Add(outbound);
            }

            // 设置直连，放前面作为主出站
            var freedomOutbound = new V2Ray.OutboundObject
            {
                Protocol = "freedom",
                Tag = Global.directTag,
                Settings = new V2Ray.Protocols.Freedom.OutboundConfigurationObject()
            };
            v2rayConfig.Outbounds.Add(freedomOutbound);

            // 设置黑名单
            var blackholeOutbound = new V2Ray.OutboundObject
            {
                Protocol = "blackhole",
                Tag = Global.blockTag,
                Settings = new V2Ray.Protocols.Blackhole.OutboundConfigurationObject()
            };
            v2rayConfig.Outbounds.Add(blackholeOutbound);

            return 0;
        }

        /// <summary>
        /// 服务器底层传输配置
        /// </summary>
        /// <param name="config"></param>
        /// <param name="iobound"></param>
        /// <param name="streamSettings"></param>
        /// <returns></returns>
        private static int boundStreamSettings(Config.V2RayNConfig config, ref V2Ray.Transport.StreamSettingsObject streamSettings)
        {

            // 底层传输配置
            streamSettings.Network = config.network();
            string host = config.requestHost();
            //if tls
            if (config.streamSecurity() == Global.StreamSecurity)
            {
                streamSettings.Security = config.streamSecurity();
                streamSettings.TlsSettings = new();
                streamSettings.TlsSettings.AllowInsecure = config.allowInsecure();

                if (!string.IsNullOrWhiteSpace(host))
                {
                    streamSettings.TlsSettings.ServerName = Utils.String2List(host)[0];
                }
            }

            //streamSettings
            switch (config.network())
            {
                //kcp基本配置暂时是默认值，用户能自己设置伪装类型
                case "kcp":
                    streamSettings.KcpSettings = new() { Mtu = config.kcpItem.mtu, Tti = config.kcpItem.tti };
                    var kcpSettings = streamSettings.KcpSettings;
                    // 不区客户端和服务
                    kcpSettings.UplinkCapacity = config.kcpItem.uplinkCapacity;
                    kcpSettings.DownlinkCapacity = config.kcpItem.downlinkCapacity;

                    kcpSettings.Congestion = config.kcpItem.congestion;
                    kcpSettings.ReadBufferSize = config.kcpItem.readBufferSize;
                    kcpSettings.WriteBufferSize = config.kcpItem.writeBufferSize;
                    kcpSettings.Header.Type = config.headerType();
                    if (!Utils.IsNullOrEmpty(config.path()))
                    {
                        kcpSettings.Seed = config.path();
                    }
                    break;
                //ws
                case "ws":
                    streamSettings.WsSettings = new();
                    var wsSettings = streamSettings.WsSettings;

                    string path = config.path();
                    if (!string.IsNullOrWhiteSpace(host))
                    {
                        wsSettings.Headers.Add("Host", $"{host}");
                    }
                    if (!string.IsNullOrWhiteSpace(path))
                    {
                        wsSettings.Path = path;
                    }

                    break;
                //h2
                case "h2":
                    streamSettings.HttpSettings = new();
                    var httpSettings = streamSettings.HttpSettings;

                    if (!string.IsNullOrWhiteSpace(host))
                    {
                        httpSettings.Host = Utils.String2List(host);
                    }
                    httpSettings.Path = config.path();

                    break;
                //quic
                case "quic":
                    streamSettings.QuicSettings = new()
                    {
                        Security = host,
                        Key = config.path(),
                        Header = new()
                        {
                            Type = config.headerType()
                        }
                    };
                    if (config.streamSecurity() == Global.StreamSecurity)
                    {
                        streamSettings.TlsSettings.ServerName = config.address();
                    }
                    break;
                default:
                    //tcp带http伪装
                    if (config.headerType().Equals(Global.TcpHeaderHttp))
                    {
                        // 这块订阅基本没法用
                        streamSettings.TcpSettings = Utils.DeepCopy(V2Ray.Transport.TcpObject.DefaultHttp);
                        var header = (V2Ray.Transport.Header.HttpHeaderObject)streamSettings.TcpSettings.Header;

                        //request填入自定义Host
                        if (!string.IsNullOrWhiteSpace(host))
                        {
                            header.request.Headers["Host"] = host.Split(',').ToList();
                        }

                        //填入自定义Path
                        if (!Utils.IsNullOrEmpty(config.path()))
                        {
                            header.request.Path = config.path().Split(',').ToList();
                        }
                    }
                    break;
            }
            return 0;
        }

        /// <summary>
        /// remoteDNS
        /// </summary>
        /// <param name="config"></param>
        /// <param name="v2rayConfig"></param>
        /// <returns></returns>
        private static int SetDNS(Config.V2RayNConfig config, ref V2RayConfig v2rayConfig)
        {
            if (!string.IsNullOrWhiteSpace(config.remoteDNS))
            {
                foreach (var server in config.remoteDNS.Split(','))
                {
                    v2rayConfig.Dns.Servers.Add(server.TrimEx());
                }
            }

            return 0;
        }

        public static int SetAPI(Config.V2RayNConfig config, ref V2RayConfig v2rayConfig)
        {
            if (config.enableStatistics)
            {
                v2rayConfig.Api = new()
                {
                    Tag = "api",
                    Services = new()
                    {
                        "StatsService",
                    },
                };
                v2rayConfig.Policy = new()
                {
                    System = new()
                    {
                        StatsOutboundUplink = true,
                        StatsOutboundDownlink = true
                    }
                };

                var apiInbound = new V2Ray.InboundObject
                {
                    Tag = Global.InboundAPITagName,
                    Listen = Global.Loopback,
                    Port = Global.v2rayApiPort,
                    Protocol = Global.InboundAPIProtocal,
                    Settings = new V2Ray.Protocols.Dokodemo_door.InboundConfigurationObject(Global.Loopback, "tcp,udp")
                };
                v2rayConfig.Inbounds.Add(apiInbound);

                var apiRule = new V2Ray.Routing.RuleObject
                {
                    Type = "field",
                    InboundTag = new() { $"{Global.InboundAPITagName}" },
                    OutboundTag = Global.InboundAPITagName
                };
                // 需要放到最前面
                v2rayConfig.Routing.Rules.Insert(0, apiRule);
            }
            return 0;
        }

        /// <summary>
        /// 生成v2ray的客户端配置文件(自定义配置)
        /// </summary>
        /// <param name="config"></param>
        /// <param name="fileName"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static int GenerateClientCustomConfig(Config.V2RayNConfig config, string fileName, out string msg)
        {
            try
            {
                //检查GUI设置
                if (config == null
                    || config.index < 0
                    || config.vmess.Count <= 0
                    || config.index > config.vmess.Count - 1
                    )
                {
                    msg = Utils.StringsRes.I18N("CheckServerSettings");
                    return -1;
                }

                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                string addressFileName = config.address();
                if (!File.Exists(addressFileName))
                {
                    addressFileName = Path.Combine(Utils.GetTempPath(), addressFileName);
                }
                if (!File.Exists(addressFileName))
                {
                    msg = Utils.StringsRes.I18N("FailedGenDefaultConfiguration");
                    return -1;
                }
                File.Copy(addressFileName, fileName);

                msg = string.Format(Utils.StringsRes.I18N("SuccessfulConfiguration"), config.getSummary());
            }
            catch
            {
                msg = Utils.StringsRes.I18N("FailedGenDefaultConfiguration");
                return -1;
            }
            return 0;
        }

        #endregion

        #region 从剪贴板导入
        /// <summary>
        /// 从剪贴板导入URL
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static VmessItem ImportFromClipboardConfig(string clipboardData, out string msg)
        {
            msg = string.Empty;
            VmessItem vmessItem = new VmessItem();

            try
            {
                //载入配置文件 
                string result = clipboardData.TrimEx();// Utils.GetClipboardData();
                if (Utils.IsNullOrEmpty(result))
                {
                    msg = Utils.StringsRes.I18N("FailedReadConfiguration");
                    return null;
                }

                if (result.StartsWith(Global.vmessProtocol))
                {
                    int indexSplit = result.IndexOf("?");
                    if (indexSplit > 0)
                    {
                        vmessItem = ResolveStdVmess(result) ?? ResolveVmess4Kitsunebi(result);
                    }
                    else
                    {
                        vmessItem.configType = (int)EConfigType.Vmess;
                        result = result.Substring(Global.vmessProtocol.Length);
                        result = Utils.Base64Decode(result);

                        //转成Json
                        VmessQRCode vmessQRCode = Utils.FromJson<VmessQRCode>(result);
                        if (vmessQRCode == null)
                        {
                            msg = Utils.StringsRes.I18N("FailedConversionConfiguration");
                            return null;
                        }
                        vmessItem.security = Global.DefaultSecurity;
                        vmessItem.network = Global.DefaultNetwork;
                        vmessItem.headerType = Global.None;


                        vmessItem.configVersion = Utils.ToString(vmessQRCode.v);
                        vmessItem.remarks = Utils.ToString(vmessQRCode.ps);
                        vmessItem.address = Utils.ToString(vmessQRCode.add);
                        vmessItem.port = Utils.ToInt(vmessQRCode.port);
                        vmessItem.id = Utils.ToString(vmessQRCode.id);
                        vmessItem.alterId = Utils.ToInt(vmessQRCode.aid);

                        if (!Utils.IsNullOrEmpty(vmessQRCode.net))
                        {
                            vmessItem.network = vmessQRCode.net;
                        }
                        if (!Utils.IsNullOrEmpty(vmessQRCode.type))
                        {
                            vmessItem.headerType = vmessQRCode.type;
                        }

                        vmessItem.requestHost = Utils.ToString(vmessQRCode.host);
                        vmessItem.path = Utils.ToString(vmessQRCode.path);
                        vmessItem.streamSecurity = Utils.ToString(vmessQRCode.tls);
                    }
                }
                else if (result.StartsWith(Global.ssProtocol))
                {
                    msg = Utils.StringsRes.I18N("ConfigurationFormatIncorrect");

                    vmessItem = ResolveSSLegacy(result);
                    if (vmessItem == null)
                    {
                        vmessItem = ResolveSip002(result);
                    }
                    if (vmessItem == null)
                    {
                        return null;
                    }
                    if (vmessItem.address.Length == 0 || vmessItem.port == 0 || vmessItem.security.Length == 0 || vmessItem.id.Length == 0)
                    {
                        return null;
                    }

                    vmessItem.configType = (int)EConfigType.Shadowsocks;
                }
                else if (result.StartsWith(Global.socksProtocol))
                {
                    msg = Utils.StringsRes.I18N("ConfigurationFormatIncorrect");

                    vmessItem.configType = (int)EConfigType.Socks;
                    result = result.Substring(Global.socksProtocol.Length);
                    //remark
                    int indexRemark = result.IndexOf("#");
                    if (indexRemark > 0)
                    {
                        try
                        {
                            vmessItem.remarks = WebUtility.UrlDecode(result.Substring(indexRemark + 1, result.Length - indexRemark - 1));
                        }
                        catch { }
                        result = result.Substring(0, indexRemark);
                    }
                    //part decode
                    int indexS = result.IndexOf("@");
                    if (indexS > 0)
                    {
                    }
                    else
                    {
                        result = Utils.Base64Decode(result);
                    }

                    string[] arr1 = result.Split('@');
                    if (arr1.Length != 2)
                    {
                        return null;
                    }
                    string[] arr21 = arr1[0].Split(':');
                    //string[] arr22 = arr1[1].Split(':');
                    int indexPort = arr1[1].LastIndexOf(":");
                    if (arr21.Length != 2 || indexPort < 0)
                    {
                        return null;
                    }
                    vmessItem.address = arr1[1].Substring(0, indexPort);
                    vmessItem.port = Utils.ToInt(arr1[1].Substring(indexPort + 1, arr1[1].Length - (indexPort + 1)));
                    vmessItem.security = arr21[0];
                    vmessItem.id = arr21[1];
                }
                else if (result.StartsWith(Global.trojanProtocol))
                {
                    msg = Utils.StringsRes.I18N("ConfigurationFormatIncorrect");

                    vmessItem.configType = (int)EConfigType.Trojan;

                    Uri uri = new Uri(result);
                    vmessItem.address = uri.IdnHost;
                    vmessItem.port = uri.Port;
                    vmessItem.id = uri.UserInfo;

                    var qurery = HttpUtility.ParseQueryString(uri.Query);
                    vmessItem.requestHost = qurery["sni"] ?? "";

                    var remarks = uri.Fragment.Replace("#", "");
                    if (Utils.IsNullOrEmpty(remarks))
                    {
                        vmessItem.remarks = "NONE";
                    }
                    else
                    {
                        vmessItem.remarks = WebUtility.UrlDecode(remarks);
                    }
                }
                else
                {
                    msg = Utils.StringsRes.I18N("NonvmessOrssProtocol");
                    return null;
                }
            }
            catch
            {
                msg = Utils.StringsRes.I18N("Incorrectconfiguration");
                return null;
            }

            return vmessItem;
        }

        private static VmessItem ResolveVmess4Kitsunebi(string result)
        {
            VmessItem vmessItem = new VmessItem
            {
                configType = (int)EConfigType.Vmess
            };
            result = result.Substring(Global.vmessProtocol.Length);
            int indexSplit = result.IndexOf("?");
            if (indexSplit > 0)
            {
                result = result.Substring(0, indexSplit);
            }
            result = Utils.Base64Decode(result);

            string[] arr1 = result.Split('@');
            if (arr1.Length != 2)
            {
                return null;
            }
            string[] arr21 = arr1[0].Split(':');
            string[] arr22 = arr1[1].Split(':');
            if (arr21.Length != 2 || arr21.Length != 2)
            {
                return null;
            }

            vmessItem.address = arr22[0];
            vmessItem.port = Utils.ToInt(arr22[1]);
            vmessItem.security = arr21[0];
            vmessItem.id = arr21[1];

            vmessItem.network = Global.DefaultNetwork;
            vmessItem.headerType = Global.None;
            vmessItem.remarks = "Alien";
            vmessItem.alterId = 0;

            return vmessItem;
        }

        private static VmessItem ResolveSip002(string result)
        {
            Uri parsedUrl;
            try
            {
                parsedUrl = new Uri(result);
            }
            catch (UriFormatException)
            {
                return null;
            }
            VmessItem server = new VmessItem
            {
                remarks = parsedUrl.GetComponents(UriComponents.Fragment, UriFormat.Unescaped),
                address = parsedUrl.IdnHost,
                port = parsedUrl.Port,
            };

            // parse base64 UserInfo
            string rawUserInfo = parsedUrl.GetComponents(UriComponents.UserInfo, UriFormat.Unescaped);
            string base64 = rawUserInfo.Replace('-', '+').Replace('_', '/');    // Web-safe base64 to normal base64
            string userInfo;
            try
            {
                userInfo = Encoding.UTF8.GetString(Convert.FromBase64String(
                base64.PadRight(base64.Length + (4 - base64.Length % 4) % 4, '=')));
            }
            catch (FormatException)
            {
                return null;
            }
            string[] userInfoParts = userInfo.Split(new char[] { ':' }, 2);
            if (userInfoParts.Length != 2)
            {
                return null;
            }
            server.security = userInfoParts[0];
            server.id = userInfoParts[1];

            NameValueCollection queryParameters = HttpUtility.ParseQueryString(parsedUrl.Query);
            if (queryParameters["plugin"] != null)
            {
                return null;
            }

            return server;
        }

        private static readonly Regex UrlFinder = new Regex(@"ss://(?<base64>[A-Za-z0-9+-/=_]+)(?:#(?<tag>\S+))?", RegexOptions.IgnoreCase);
        private static readonly Regex DetailsParser = new Regex(@"^((?<method>.+?):(?<password>.*)@(?<hostname>.+?):(?<port>\d+?))$", RegexOptions.IgnoreCase);

        private static VmessItem ResolveSSLegacy(string result)
        {
            var match = UrlFinder.Match(result);
            if (!match.Success)
            {
                return null;
            }

            VmessItem server = new VmessItem();
            var base64 = match.Groups["base64"].Value.TrimEnd('/');
            var tag = match.Groups["tag"].Value;
            if (!tag.IsNullOrEmpty())
            {
                server.remarks = HttpUtility.UrlDecode(tag, Encoding.UTF8);
            }
            Match details;
            try
            {
                details = DetailsParser.Match(Encoding.UTF8.GetString(Convert.FromBase64String(
                    base64.PadRight(base64.Length + (4 - base64.Length % 4) % 4, '='))));
            }
            catch (FormatException)
            {
                return null;
            }
            if (!details.Success)
            {
                return null;
            }

            server.security = details.Groups["method"].Value;
            server.id = details.Groups["password"].Value;
            server.address = details.Groups["hostname"].Value;
            server.port = int.Parse(details.Groups["port"].Value);
            return server;
        }


        private static readonly Regex StdVmessUserInfo = new Regex(
            @"^(?<network>[a-z]+)(\+(?<streamSecurity>[a-z]+))?:(?<id>[0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12})-(?<alterId>[0-9]+)$");

        private static VmessItem ResolveStdVmess(string result)
        {
            VmessItem i = new VmessItem
            {
                configType = (int)EConfigType.Vmess,
                security = "auto"
            };

            Uri u = new Uri(result);

            i.address = u.IdnHost;
            i.port = u.Port;
            i.remarks = u.GetComponents(UriComponents.Fragment, UriFormat.Unescaped);
            var q = HttpUtility.ParseQueryString(u.Query);

            var m = StdVmessUserInfo.Match(u.UserInfo);
            if (!m.Success)
            {
                return null;
            }

            i.id = m.Groups["id"].Value;
            if (!int.TryParse(m.Groups["alterId"].Value, out int aid))
            {
                return null;
            }
            i.alterId = aid;

            if (m.Groups["streamSecurity"].Success)
            {
                i.streamSecurity = m.Groups["streamSecurity"].Value;
            }
            switch (i.streamSecurity)
            {
                case "tls":
                    // TODO tls config
                    break;
                default:
                    if (!string.IsNullOrWhiteSpace(i.streamSecurity))
                    {
                        return null;
                    }

                    break;
            }

            i.network = m.Groups["network"].Value;
            switch (i.network)
            {
                case "tcp":
                    string t1 = q["type"] ?? "none";
                    i.headerType = t1;
                    // TODO http option

                    break;
                case "kcp":
                    i.headerType = q["type"] ?? "none";
                    // TODO kcp seed
                    break;

                case "ws":
                    string p1 = q["path"] ?? "/";
                    string h1 = q["host"] ?? "";
                    i.requestHost = h1;
                    i.path = p1;
                    break;

                case "http":
                    i.network = "h2";
                    string p2 = q["path"] ?? "/";
                    string h2 = q["host"] ?? "";
                    i.requestHost = h2;
                    i.path = p2;
                    break;

                case "quic":
                    string s = q["security"] ?? "none";
                    string k = q["key"] ?? "";
                    string t3 = q["type"] ?? "none";
                    i.headerType = t3;
                    i.requestHost = s;
                    i.path = k;
                    break;

                default:
                    return null;
            }

            return i;
        }
        #endregion

        #region 生成速度测试的配置
        public static string GenerateClientSpeedtestConfigString(Config.V2RayNConfig config, List<int> selecteds, out string msg)
        {
            try
            {
                if (config == null
                    || config.index < 0
                    || config.vmess.Count <= 0
                    || config.index > config.vmess.Count - 1
                    )
                {
                    msg = Utils.StringsRes.I18N("CheckServerSettings");
                    return "";
                }

                msg = Utils.StringsRes.I18N("InitialConfiguration");

                Config.V2RayNConfig configCopy = Utils.DeepCopy(config);

                V2RayConfig v2rayConfig = V2RayConfig.SpeedTest;
                if (v2rayConfig == null)
                {
                    msg = Utils.StringsRes.I18N("FailedGenDefaultConfiguration");
                    return "";
                }

                int httpPort = configCopy.GetLocalPort("speedtest");
                foreach (int index in selecteds)
                {
                    if (configCopy.vmess[index].configType == (int)EConfigType.Custom)
                    {
                        continue;
                    }

                    configCopy.index = index;

                    var port = httpPort + index;
                    v2rayConfig.Inbounds.Add(new()
                    {
                        Listen = Global.Loopback,
                        Port = port,
                        Protocol = Global.InboundHttp,
                        Tag = Global.InboundHttp + port.ToString()
                    });


                    V2RayConfig v2rayConfigCopy = V2RayConfig.SpeedTest;
                    SetOutbound(configCopy, ref v2rayConfigCopy);
                    v2rayConfigCopy.Outbounds[0].Tag = Global.agentTag + port.ToString();
                    v2rayConfig.Outbounds.Add(v2rayConfigCopy.Outbounds[0]);

                    v2rayConfig.Routing.Rules.Add(new()
                    {
                        InboundTag = new() { Global.InboundHttp + port.ToString() },
                        OutboundTag = Global.agentTag + port.ToString(),
                    });
                }

                msg = string.Format(Utils.StringsRes.I18N("SuccessfulConfiguration"), configCopy.getSummary());
                return Utils.ToJson(v2rayConfig, true);
            }
            catch (Exception e)
            {
                msg = Utils.StringsRes.I18N("FailedGenDefaultConfiguration");
                Utils.SaveLog(e.Message, e);
                return "";
            }
        }

        #endregion

    }
}
