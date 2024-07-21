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
using v2rayN.Extensions;
using V2Ray = Shadowsocks.Interop.V2Ray;
using V2RayConfig = Shadowsocks.Interop.V2Ray.Config;

namespace v2rayN.Handlers;

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
            if (config == null || config.node == null)
            {
                msg = StringsRes.I18N("CheckServerSettings");
                return -1;
            }

            msg = StringsRes.I18N("InitialConfiguration");
            if (config.node.configType == EConfigType.Custom)
            {
                return GenerateClientCustomConfig(config, fileName, out msg);
            }

            //转成Json
            var v2rayConfig = V2RayConfig.Default;

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

            Json.ToJsonFile(v2rayConfig, fileName, false, true);

            msg = string.Format(StringsRes.I18N("SuccessfulConfiguration"), config.getSummary());
        }
        catch (Exception e)
        {
            msg = StringsRes.I18N("FailedGenDefaultConfiguration");
            Log.SaveLog(e.Message, e);
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
                v2rayConfig.Log.Access = Misc.GetPath(v2rayConfig.Log.Access);
                v2rayConfig.Log.Error = Misc.GetPath(v2rayConfig.Log.Error);
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
        socksInbound.Sniffing.RouteOnly = config.inbound[0].sniffingEnabled;

        // http proxy
        var httpInbound = V2Ray.InboundObject.DefaultLocalHttp;
        httpInbound.Listen = socksInbound.Listen;
        httpInbound.Tag = "httpProxy";
        httpInbound.Port = config.inbound[0].localPort + 1;
        httpInbound.Sniffing.Enabled = config.inbound[0].sniffingEnabled;
        httpInbound.Sniffing.RouteOnly = config.inbound[0].sniffingEnabled;

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
        if (v2rayConfig.Routing != null && v2rayConfig.Routing.Rules != null)
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
                if (Misc.IsNullOrEmpty(url))
                {
                    continue;
                }
                if (Misc.IsIP(url) || url.StartsWith("geoip:"))
                {
                    ipRule.Ip.Add(url);
                }
                else if (
                    Misc.IsDomain(url)
                    || url.StartsWith("geosite:")
                    || url.StartsWith("regexp:")
                    || url.StartsWith("domain:")
                    || url.StartsWith("full:")
                )
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
        if (config.node.configType == EConfigType.VMess)
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
        else if (config.node.configType == EConfigType.Shadowsocks)
        {
            var outbound = V2Ray.OutboundObject.GetShadowsocks(Global.agentTag);
            var settings = (V2Ray.Protocols.Shadowsocks.OutboundConfigurationObject)outbound.Settings;

            //远程服务器地址和端口
            settings.Servers.Add(new());
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
        else if (config.node.configType == EConfigType.Socks)
        {
            var outbound = V2Ray.OutboundObject.GetSocks(
                Global.agentTag,
                new DnsEndPoint(config.address(), config.port())
            );
            var settings = (V2Ray.Protocols.Socks.OutboundConfigurationObject)outbound.Settings;

            if (!Misc.IsNullOrEmpty(config.security()) && !Misc.IsNullOrEmpty(config.id()))
            {
                settings
                    .Servers[0]
                    .Users.Add(
                        new()
                        {
                            User = config.security(),
                            Pass = config.id(),
                            Level = 1
                        }
                    );
            }

            //Mux
            outbound.Mux = new();
            outbound.Mux.Enabled = config.muxEnabled;
            outbound.Mux.Concurrency = config.muxEnabled ? 8 : -1;

            v2rayConfig.Outbounds.Add(outbound);
        }
        else if (config.node.configType == EConfigType.VLESS)
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

            if (
                config.streamSecurity() == Global.StreamSecurityReality
                || config.streamSecurity() == Global.StreamSecurity
            )
            {
                if (!Misc.IsNullOrEmpty(config.flow()))
                {
                    settings.Vnext[0].Users[0].Flow = config.flow();
                    outbound.Mux.Enabled = false;
                }
            }

            //远程服务器底层传输配置
            var streamSettings = new V2Ray.Transport.StreamSettingsObject();
            boundStreamSettings(config, ref streamSettings);
            outbound.StreamSettings = streamSettings;

            v2rayConfig.Outbounds.Add(outbound);
        }
        else if (config.node.configType == EConfigType.Trojan)
        {
            var outbound = V2Ray.OutboundObject.GetTrojan(
                Global.agentTag,
                config.address(),
                config.port(),
                config.id()
            );

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
    private static int boundStreamSettings(
        Config.V2RayNConfig config,
        ref V2Ray.Transport.StreamSettingsObject streamSettings
    )
    {
        // 底层传输配置
        streamSettings.Network = config.network();
        string host = config.requestHost().TrimEx();
        string sni = config.node.sni;
        string useragent =
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 YaBrowser/24.4.0.0 Safari/537.36";
        //if tls
        if (config.streamSecurity() == Global.StreamSecurity)
        {
            streamSettings.Security = config.streamSecurity();
            streamSettings.TlsSettings = new();
            streamSettings.TlsSettings.AllowInsecure = config.allowInsecure();
            streamSettings.TlsSettings.Alpn = config.alpn();
            streamSettings.TlsSettings.Fingerprint = config.fingerprint();

            if (!Misc.IsNullOrEmpty(sni))
            {
                streamSettings.TlsSettings.ServerName = sni;
            }
            if (!string.IsNullOrWhiteSpace(host))
            {
                streamSettings.TlsSettings.ServerName = Misc.String2List(host)[0];
            }
        }
        //if Reality
        if (config.streamSecurity() == Global.StreamSecurityReality)
        {
            // TODO
            throw new Exception("no support reality stream setting");
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
                if (!Misc.IsNullOrEmpty(config.path()))
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
                    wsSettings.Headers.Add("Host", host);
                }
                if (!string.IsNullOrWhiteSpace(path))
                {
                    wsSettings.Path = path;
                }
                wsSettings.Headers.Add("User-Agent", useragent);

                break;
            //h2
            case "h2":
                streamSettings.HttpSettings = new();
                var httpSettings = streamSettings.HttpSettings;

                if (!string.IsNullOrWhiteSpace(host))
                {
                    httpSettings.Host = Misc.String2List(host);
                }
                httpSettings.Path = config.path();

                break;
            //quic
            case "quic":
                streamSettings.QuicSettings = new()
                {
                    Security = host,
                    Key = config.path(),
                    Header = new() { Type = config.headerType() }
                };
                if (config.streamSecurity() == Global.StreamSecurity)
                {
                    if (!Misc.IsNullOrEmpty(sni))
                        streamSettings.TlsSettings.ServerName = sni;
                    else
                        streamSettings.TlsSettings.ServerName = config.address();
                }
                break;
            default:
                //tcp带http伪装
                if (config.headerType().Equals(Global.TcpHeaderHttp))
                {
                    // 这块订阅基本没法用
                    var header = new V2Ray.Transport.Header.HttpHeaderObject();
                    streamSettings.TcpSettings = new() { Header = header };

                    //request填入自定义Host
                    if (!string.IsNullOrWhiteSpace(host))
                    {
                        header.request.Headers["Host"] = host.Split(',').ToList();
                    }

                    //填入自定义Path
                    if (!Misc.IsNullOrEmpty(config.path()))
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
                Services = new() { "StatsService", },
            };
            v2rayConfig.Policy = new()
            {
                System = new() { StatsOutboundUplink = true, StatsOutboundDownlink = true }
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
            if (config == null || config.node == null)
            {
                msg = StringsRes.I18N("CheckServerSettings");
                return -1;
            }

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            string addressFileName = config.address();
            if (!File.Exists(addressFileName))
            {
                addressFileName = Path.Combine(Misc.GetTempPath(), addressFileName);
            }
            if (!File.Exists(addressFileName))
            {
                msg = StringsRes.I18N("FailedGenDefaultConfiguration");
                return -1;
            }
            File.Copy(addressFileName, fileName);

            msg = string.Format(StringsRes.I18N("SuccessfulConfiguration"), config.getSummary());
        }
        catch
        {
            msg = StringsRes.I18N("FailedGenDefaultConfiguration");
            return -1;
        }
        return 0;
    }

    /// <summary>
    /// 生成速度测试的配置
    /// </summary>
    /// <param name="config"></param>
    /// <param name="selecteds"></param>
    /// <param name="msg"></param>
    /// <returns></returns>
    public static string GenerateClientSpeedtestConfigString(
        Config.V2RayNConfig config,
        List<int> selecteds,
        out string msg
    )
    {
        try
        {
            if (config == null || config.node == null)
            {
                msg = StringsRes.I18N("CheckServerSettings");
                return "";
            }

            msg = StringsRes.I18N("InitialConfiguration");

            Config.V2RayNConfig configCopy = Misc.DeepCopy(config);

            V2RayConfig v2rayConfig = V2RayConfig.SpeedTest;
            if (v2rayConfig == null)
            {
                msg = StringsRes.I18N("FailedGenDefaultConfiguration");
                return "";
            }

            int httpPort = configCopy.GetLocalPort("speedtest");
            foreach (int index in selecteds)
            {
                if (configCopy.vmess[index].configType == EConfigType.Custom)
                    continue;

                configCopy.index = index;

                var port = httpPort + index;
                v2rayConfig.Inbounds.Add(
                    new()
                    {
                        Listen = Global.Loopback,
                        Port = port,
                        Protocol = Global.InboundHttp,
                        Tag = Global.InboundHttp + port.ToString()
                    }
                );

                V2RayConfig v2rayConfigCopy = V2RayConfig.SpeedTest;
                SetOutbound(configCopy, ref v2rayConfigCopy);
                v2rayConfigCopy.Outbounds[0].Tag = Global.agentTag + port.ToString();
                v2rayConfig.Outbounds.Add(v2rayConfigCopy.Outbounds[0]);

                v2rayConfig.Routing.Rules.Add(
                    new()
                    {
                        InboundTag = new() { Global.InboundHttp + port.ToString() },
                        OutboundTag = Global.agentTag + port.ToString(),
                    }
                );
            }

            msg = string.Format(StringsRes.I18N("SuccessfulConfiguration"), configCopy.getSummary());
            return Json.ToJson(v2rayConfig, true);
        }
        catch (Exception e)
        {
            msg = StringsRes.I18N("FailedGenDefaultConfiguration");
            Log.SaveLog(e.Message, e);
            return "";
        }
    }

    #endregion
}
