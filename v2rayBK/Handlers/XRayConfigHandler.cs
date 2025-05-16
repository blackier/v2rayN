using System.Net;
using ServiceLib.Enums;
using ServiceLib.Models;
using Shadowsocks.Interop.V2Ray.Dns;
using Shadowsocks.Interop.V2Ray.Inbound;
using v2rayBK.Common;
using v2rayBK.ViewModels;
using V2Ray = Shadowsocks.Interop.V2Ray;
using V2RayConfig = Shadowsocks.Interop.V2Ray.Config;

namespace v2rayBK.Handlers;

/// <summary>
/// v2ray配置文件处理类
/// </summary>
public class XRayConfigHandler
{
    public static bool GenerateClientConfig(v2rayBKConfig config, string fileName, bool blExport, out string msg)
    {
        try
        {
            if (config.GetSelectedProfile() == null)
            {
                msg = "InvalidConfiguration";
                return false;
            }

            var v2rayConfig = V2RayConfig.Default;

            //开始修改配置
            SetLog(config, v2rayConfig, blExport);

            //本地端口
            SetInbound(config, v2rayConfig);

            //dns
            SetDNS(config, v2rayConfig);

            //路由
            SetRouting(config, v2rayConfig);

            //outbound
            SetOutbound(config, v2rayConfig, config.GetSelectedProfile());

            // 统计配置
            SetAPI(config, v2rayConfig);

            //转成Json
            Json.ToJsonFile(v2rayConfig, fileName, false, true);

            msg = "SuccessfulConfiguration";
        }
        catch (Exception e)
        {
            msg = "FailedGenDefaultConfiguration";
            App.PostLog(e.Message);
        }
        return true;
    }

    private static int SetLog(v2rayBKConfig config, V2RayConfig v2rayConfig, bool blExport)
    {
        if (blExport)
        {
            if (config.LogEnabled)
            {
                v2rayConfig.Log.Loglevel = config.LogLevel;
            }
            else
            {
                v2rayConfig.Log.Loglevel = config.LogLevel;
                v2rayConfig.Log.Access = "";
                v2rayConfig.Log.Error = "";
            }
        }
        else
        {
            if (config.LogEnabled)
            {
                v2rayConfig.Log.Loglevel = config.LogLevel;
                v2rayConfig.Log.Access = Utils.GetPath(v2rayConfig.Log.Access);
                v2rayConfig.Log.Error = Utils.GetPath(v2rayConfig.Log.Error);
            }
            else
            {
                v2rayConfig.Log.Loglevel = config.LogLevel;
                v2rayConfig.Log.Access = "";
                v2rayConfig.Log.Error = "";
            }
        }
        return 0;
    }

    private static int SetInbound(v2rayBKConfig config, V2RayConfig v2rayConfig)
    {
        // socks proxy
        var socksInbound = V2Ray.InboundObject.DefaultLocalSocks;
        socksInbound.Tag = "socksProxy";
        // 端口
        socksInbound.Port = config.SocksInboundPort;
        if (config.AllowLANConn)
            socksInbound.Listen = "0.0.0.0";
        else
            socksInbound.Listen = Global.Loopback;
        // 流量探测
        if (config.FakednsEnabled)
            socksInbound.Sniffing = SniffingObject.DefaultFakeDns;
        socksInbound.Sniffing.Enabled = config.SniffingEnabled;
        socksInbound.Sniffing.RouteOnly = config.SniffingEnabled;

        // http proxy
        var httpInbound = V2Ray.InboundObject.DefaultLocalHttp;
        httpInbound.Listen = socksInbound.Listen;
        httpInbound.Tag = "httpProxy";
        httpInbound.Port = config.HttpInboundPort;

        if (config.FakednsEnabled)
            httpInbound.Sniffing = SniffingObject.DefaultFakeDns;
        httpInbound.Sniffing.Enabled = config.SniffingEnabled;
        httpInbound.Sniffing.RouteOnly = config.SniffingEnabled;

        v2rayConfig.Inbounds.Add(socksInbound);
        v2rayConfig.Inbounds.Add(httpInbound);

        // dns入口
        if (config.LocalDNSEnabled)
        {
            var dnsInbound = new V2Ray.InboundObject
            {
                Tag = GlobalEx.dnsInTag,
                Listen = Global.Loopback,
                Port = GlobalEx.dnsPort,
                Protocol = Global.InboundAPIProtocol,
                Settings = new V2Ray.Protocols.Dokodemo_door.InboundConfigurationObject(
                    GlobalEx.DomainOverseaDNSAddress.First(),
                    "tcp,udp"
                )
            };
            v2rayConfig.Inbounds.Add(dnsInbound);
        }
        return 0;
    }

    private static int SetRouting(v2rayBKConfig config, V2RayConfig v2rayConfig)
    {
        v2rayConfig.Routing.DomainStrategy = config.DomainStrategy;

        // DNS设置
        // DNS本地服务入口
        var dnsHostRule = new V2Ray.Routing.RuleObject
        {
            Type = "field",
            InboundTag = new() { GlobalEx.dnsInTag },
            OutboundTag = GlobalEx.dnsOutTag,
        };
        v2rayConfig.Routing.Rules.Add(dnsHostRule);

        // DNS代理固定的几个
        var dnsServerProxyRule = new V2Ray.Routing.RuleObject
        {
            Type = "field",
            Ip = GlobalEx.DomainOverseaDNSAddress,
            OutboundTag = Global.ProxyTag,
        };
        v2rayConfig.Routing.Rules.Add(dnsServerProxyRule);

        // DNS其他直接直连
        var dnsServerDirectRule = new V2Ray.Routing.RuleObject
        {
            Type = "field",
            InboundTag = new() { GlobalEx.dnsServerTag },
            OutboundTag = Global.DirectTag,
        };
        v2rayConfig.Routing.Rules.Add(dnsServerDirectRule);

        //自定义
        //需代理
        RoutingUserRule(config, v2rayConfig, config.UserProxy, Global.ProxyTag);
        //直连
        RoutingUserRule(config, v2rayConfig, config.UserDirect, Global.DirectTag);
        //阻止
        RoutingUserRule(config, v2rayConfig, config.UserBlock, Global.BlockTag);
        return 0;
    }

    private static int RoutingUserRule(
        v2rayBKConfig config,
        V2RayConfig v2rayConfig,
        ObservableCollection<RoutingRuleItem> userRule,
        string tag
    )
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

            foreach (RoutingRuleItem rule in userRule)
            {
                if (!rule.Enable)
                    continue;
                foreach (var u in rule.Domain)
                {
                    string url = u.TrimEx();
                    if (url.IsNullOrEmpty())
                    {
                        continue;
                    }
                    if (Misc.IsIP(url) || url.StartsWith("geoip:"))
                    {
                        ipRule.Ip.Add(url);
                    }
                    else if (
                        Utils.IsDomain(url)
                        || url.StartsWith("geosite:")
                        || url.StartsWith("regexp:")
                        || url.StartsWith("domain:")
                        || url.StartsWith("full:")
                    )
                    {
                        domainRule.Domain.Add(url);
                    }
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
            // dns server direct
            if (tag == Global.DirectTag)
            {
                var directDNSItem = new ServerObject();
                directDNSItem.Domains = domainRule.Domain.ToList();
                directDNSItem.Address = Global.DomainDNSAddress.FirstOrDefault();
                directDNSItem.Domains.Add(config.GetSelectedProfile().Address);
                v2rayConfig.Dns.Servers.Insert(0, directDNSItem);
            }
        }
        return 0;
    }

    private static int SetOutbound(v2rayBKConfig config, V2RayConfig v2rayConfig, ProfileItem node)
    {
        // 设置代理，放前面作为主出站
        V2Ray.OutboundObject outbound = new();
        if (node.ConfigType == EConfigType.VMess)
        {
            outbound = V2Ray.OutboundObject.GetVMess(Global.ProxyTag, node.Address, node.Port, node.Id);

            var settings = (V2Ray.Protocols.VMess.OutboundConfigurationObject)outbound.Settings;
            settings.Vnext[0].Users[0].AlterId = node.AlterId;
            settings.Vnext[0].Users[0].Email = Global.UserEMail;
            settings.Vnext[0].Users[0].Security = node.Security;
        }
        else if (node.ConfigType == EConfigType.Shadowsocks)
        {
            outbound = V2Ray.OutboundObject.GetShadowsocks(Global.ProxyTag);
            var settings = (V2Ray.Protocols.Shadowsocks.OutboundConfigurationObject)outbound.Settings;

            //远程服务器地址和端口
            settings.Servers.Add(new());
            settings.Servers[0].Address = node.Address;
            settings.Servers[0].Port = node.Port;
            settings.Servers[0].Password = node.Id;
            settings.Servers[0].Method = node.Security;
            settings.Servers[0].Level = 1;
        }
        else if (node.ConfigType == EConfigType.SOCKS)
        {
            outbound = V2Ray.OutboundObject.GetSocks(Global.ProxyTag, new DnsEndPoint(node.Address, node.Port));
            var settings = (V2Ray.Protocols.Socks.OutboundConfigurationObject)outbound.Settings;

            if (!node.Security.IsNullOrEmpty() && !node.Id.IsNullOrEmpty())
            {
                settings
                    .Servers[0]
                    .Users.Add(
                        new()
                        {
                            User = node.Security,
                            Pass = node.Id,
                            Level = 1
                        }
                    );
            }
        }
        else if (node.ConfigType == EConfigType.VLESS)
        {
            outbound = V2Ray.OutboundObject.GetVLESS(Global.ProxyTag, node.Address, node.Port, node.Id);

            var settings = (V2Ray.Protocols.VLESS.OutboundConfigurationObject)outbound.Settings;

            //远程服务器用户ID
            settings.Vnext[0].Users[0].Email = Global.UserEMail;
            settings.Vnext[0].Users[0].Encryption = node.Security;
        }
        else if (node.ConfigType == EConfigType.Trojan)
        {
            outbound = V2Ray.OutboundObject.GetTrojan(Global.ProxyTag, node.Address, node.Port, node.Id);
        }

            //Mux
            outbound.Mux = new();
            outbound.Mux.Enabled = config.MuxEnabled;
            outbound.Mux.Concurrency = config.MuxEnabled ? 8 : -1;

            if (node.StreamSecurity == Global.StreamSecurityReality || node.StreamSecurity == Global.StreamSecurity)
            {
                if (!node.Flow.IsNullOrEmpty())
                {
                var settings = (V2Ray.Protocols.VLESS.OutboundConfigurationObject)outbound.Settings;
                    settings.Vnext[0].Users[0].Flow = node.Flow;
                    outbound.Mux.Enabled = false;
                }
            }

            //远程服务器底层传输配置
            var streamSettings = new V2Ray.Transport.StreamSettingsObject();
        streamSettings.Sockopt = new() { DomainStrategy = "UseIP" };
            BoundStreamSettings(config, node, streamSettings);
            outbound.StreamSettings = streamSettings;

            v2rayConfig.Outbounds.Add(outbound);

        // 设置直连
        var freedomOutbound = new V2Ray.OutboundObject
        {
            Protocol = "freedom",
            Tag = Global.DirectTag,
            Settings = new V2Ray.Protocols.Freedom.OutboundConfigurationObject()
        };
        v2rayConfig.Outbounds.Add(freedomOutbound);

        // dns解析
        var dnsOutbound = new V2Ray.OutboundObject { Protocol = "dns", Tag = GlobalEx.dnsOutTag };
        v2rayConfig.Outbounds.Add(dnsOutbound);

        // 设置黑名单
        var blackholeOutbound = new V2Ray.OutboundObject
        {
            Protocol = "blackhole",
            Tag = Global.BlockTag,
            Settings = new V2Ray.Protocols.Blackhole.OutboundConfigurationObject()
        };
        v2rayConfig.Outbounds.Add(blackholeOutbound);

        return 0;
    }

    private static int BoundStreamSettings(
        v2rayBKConfig config,
        ProfileItem node,
        V2Ray.Transport.StreamSettingsObject streamSettings
    )
    {
        // 底层传输配置
        streamSettings.Network = node.GetNetwork();
        string host = node.RequestHost.TrimEx();
        string sni = node.Sni;
        string useragent =
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 YaBrowser/24.4.0.0 Safari/537.36";
        //if tls
        if (node.StreamSecurity == Global.StreamSecurity)
        {
            streamSettings.Security = node.StreamSecurity;
            streamSettings.TlsSettings = new();
            streamSettings.TlsSettings.AllowInsecure = node.AllowInsecure.IsNullOrEmpty()
                ? config.DefAllowInsecure
                : Utils.ToBool(node.AllowInsecure);
            streamSettings.TlsSettings.Alpn = node.GetAlpn();
            streamSettings.TlsSettings.Fingerprint = node.Fingerprint;

            if (!sni.IsNullOrEmpty())
            {
                streamSettings.TlsSettings.ServerName = sni;
            }
            if (!string.IsNullOrWhiteSpace(host))
            {
                streamSettings.TlsSettings.ServerName = Utils.String2List(host)[0];
            }
        }
        //if Reality
        if (node.StreamSecurity == Global.StreamSecurityReality)
        {
            // TODO
            throw new Exception("no support reality stream setting");
        }

        //streamSettings
        switch (node.GetNetwork())
        {
            //kcp基本配置暂时是默认值，用户能自己设置伪装类型
            case nameof(ETransport.kcp):
            // TODO
            //streamSettings.KcpSettings = new() { Mtu = config.kcpItem.mtu, Tti = config.kcpItem.tti };
            //var kcpSettings = streamSettings.KcpSettings;
            //// 不区客户端和服务
            //kcpSettings.UplinkCapacity = config.kcpItem.uplinkCapacity;
            //kcpSettings.DownlinkCapacity = config.kcpItem.downlinkCapacity;

            //kcpSettings.Congestion = config.kcpItem.congestion;
            //kcpSettings.ReadBufferSize = config.kcpItem.readBufferSize;
            //kcpSettings.WriteBufferSize = config.kcpItem.writeBufferSize;
            //kcpSettings.Header.Type = node.HeaderType;
            //if (!node.Path.IsNullOrEmpty())
            //{
            //    kcpSettings.Seed = node.Path;
            //}
            case nameof(ETransport.httpupgrade):
            case nameof(ETransport.xhttp):
            case nameof(ETransport.grpc):
                throw new Exception($"no support {node.GetNetwork()} stream setting");
            case nameof(ETransport.ws):
                streamSettings.WsSettings = new();
                var wsSettings = streamSettings.WsSettings;

                string path = node.Path;
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
            case nameof(ETransport.h2):
                streamSettings.HttpSettings = new();
                var httpSettings = streamSettings.HttpSettings;

                if (!string.IsNullOrWhiteSpace(host))
                {
                    httpSettings.Host = Utils.String2List(host);
                }
                httpSettings.Path = node.Path;

                break;
            case nameof(ETransport.quic):
                streamSettings.QuicSettings = new()
                {
                    Security = host,
                    Key = node.Path,
                    Header = new() { Type = node.HeaderType }
                };
                if (node.StreamSecurity == Global.StreamSecurity)
                {
                    if (!sni.IsNullOrEmpty())
                        streamSettings.TlsSettings.ServerName = sni;
                    else
                        streamSettings.TlsSettings.ServerName = node.Address;
                }
                break;
            default:
                //tcp带http伪装
                if (node.HeaderType.Equals(Global.TcpHeaderHttp))
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
                    if (!node.Path.IsNullOrEmpty())
                    {
                        header.request.Path = node.Path.Split(',').ToList();
                    }
                }
                break;
        }
        return 0;
    }

    private static int SetDNS(v2rayBKConfig config, V2RayConfig v2rayConfig)
    {
        v2rayConfig.Dns.Tag = GlobalEx.dnsServerTag;
        if (config.FakednsEnabled)
            v2rayConfig.Dns.Servers.Add("fakedns");

        foreach (var dnsip in GlobalEx.DomainOverseaDNSAddress)
            v2rayConfig.Dns.Servers.Add(dnsip);

        return 0;
    }

    private static int SetAPI(v2rayBKConfig config, V2RayConfig v2rayConfig)
    {
        if (config.EnableStatistics)
        {
            string apiTagName = "api";
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
                Tag = apiTagName,
                Listen = Global.Loopback,
                Port = GlobalEx.v2rayApiPort,
                Protocol = Global.InboundAPIProtocol,
                Settings = new V2Ray.Protocols.Dokodemo_door.InboundConfigurationObject(Global.Loopback, "tcp,udp")
            };
            v2rayConfig.Inbounds.Add(apiInbound);

            var apiRule = new V2Ray.Routing.RuleObject
            {
                Type = "field",
                InboundTag = new() { apiTagName },
                OutboundTag = apiTagName
            };
            // 需要放到最前面
            v2rayConfig.Routing.Rules.Insert(0, apiRule);
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
    public static string GenerateClientSpeedTestConfigString(v2rayBKConfig config, List<int> selecteds)
    {
        try
        {
            V2RayConfig v2rayConfig = V2RayConfig.SpeedTest;
            if (v2rayConfig == null)
            {
                App.PostLog("FailedGenDefaultConfiguration");
                return "";
            }
            var freePort = Utils.GetFreePort();
            foreach (int index in selecteds)
            {
                var node = config.GetSelectedProfile(index);
                if (node == null)
                {
                    App.PostLog($"invalid test server index: {index}");
                    continue;
                }

                int port = freePort + index;
                config.GetSelectedServer(index)!.SpeedTestPort = port;
                var inboundTag = "http" + port.ToString();
                v2rayConfig.Inbounds.Add(
                    new()
                    {
                        Listen = Global.Loopback,
                        Port = port,
                        Protocol = "http",
                        Tag = inboundTag
                    }
                );

                var outboundTag = Global.ProxyTag + port.ToString();

                V2RayConfig v2rayConfigCopy = V2RayConfig.SpeedTest;
                SetOutbound(config, v2rayConfigCopy, node);
                v2rayConfigCopy.Outbounds[0].Tag = outboundTag;

                v2rayConfig.Outbounds.Add(v2rayConfigCopy.Outbounds[0]);
                v2rayConfig.Routing.Rules.Add(
                    new()
                    {
                        InboundTag = new() { inboundTag },
                        OutboundTag = outboundTag,
                    }
                );
            }

            App.PostLog("SuccessfulConfiguration");
            return Json.ToJson(v2rayConfig, true);
        }
        catch (Exception e)
        {
            App.PostLog("FailedGenDefaultConfiguration");
            App.PostLog(e.Message);
            return "";
        }
    }
}
