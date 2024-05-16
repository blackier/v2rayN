using System;
using System.Collections.Generic;
using v2rayN.Extensions;
using v2rayN.Handlers;
using v2rayN.Utils;

namespace v2rayN.Config;

/// <summary>
/// 本软件配置文件实体类
/// </summary>
[Serializable]
public class V2RayNConfig
{
    /// <summary>
    /// 本地监听
    /// </summary>
    public List<InItem> inbound { get; set; }

    /// <summary>
    /// 代理模式
    /// </summary>
    public ListenerType listenerType { get; set; }

    /// <summary>
    /// 允许日志
    /// </summary>
    public bool logEnabled { get; set; }

    /// <summary>
    /// 日志等级
    /// </summary>
    public string loglevel { get; set; }

    /// <summary>
    /// 允许Mux多路复用
    /// </summary>
    public bool muxEnabled { get; set; }

    /// <summary>
    /// 是否允许不安全连接
    /// </summary>
    public bool defAllowInsecure { get; set; }

    /// <summary>
    /// 自定义远程DNS
    /// </summary>
    public string remoteDNS { get; set; }

    /// <summary>
    /// 域名解析策略
    /// </summary>
    public string domainStrategy { get; set; }

    /// <summary>
    /// 路由模式
    /// </summary>
    public string routingMode { get; set; }

    /// <summary>
    /// 用户自定义需代理的网址或ip
    /// </summary>
    public List<string> useragent { get; set; }

    /// <summary>
    /// 用户自定义直连的网址或ip
    /// </summary>
    public List<string> userdirect { get; set; }

    /// <summary>
    /// 用户自定义阻止的网址或ip
    /// </summary>
    public List<string> userblock { get; set; }

    /// <summary>
    /// KcpItem
    /// </summary>
    public KcpItem kcpItem { get; set; }

    /// <summary>
    /// 允许来自局域网的连接
    /// </summary>
    public bool allowLANConn { get; set; }

    /// <summary>
    /// 启用实时网速和流量统计
    /// </summary>
    public bool enableStatistics { get; set; }

    /// <summary>
    /// 去重时优先保留较旧（顶部）节点
    /// </summary>
    public bool keepOlderDedupl { get; set; }

    /// <summary>
    /// 网速刷新率
    /// </summary>
    public int statisticsFreshRate { get; set; }

    /// <summary>
    /// 自定义服务器下载测速url
    /// </summary>
    public string speedTestUrl { get; set; }

    /// <summary>
    /// 自定义“服务器真连接延迟”测试url
    /// </summary>
    public string speedPingTestUrl { get; set; }

    /// <summary>
    /// 订阅
    /// </summary>
    public List<SubItem> subItem { get; set; }

    /// <summary>
    /// UI
    /// </summary>
    public UIItem uiItem { get; set; }

    /// <summary>
    /// 活动服务配置序号
    /// </summary>
    public int index { get; set; }

    /// <summary>
    /// vmess服务器信息
    /// </summary>
    public List<ProfileItem> vmess { get; set; }

    public ProfileItem node
    {
        get
        {
            if (index < 0 || index >= vmess.Count)
                return null;
            return vmess[index];
        }
    }

    #region 函数

    public string address()
    {
        return node?.address.Trim() ?? string.Empty;
    }

    public int port()
    {
        return node?.port ?? 10808;
    }

    public string id()
    {
        return node?.id.TrimEx() ?? string.Empty;
    }

    public int alterId()
    {
        return node?.alterId ?? 0;
    }

    public string security()
    {
        return node?.security.TrimEx() ?? string.Empty;
    }

    public string remarks()
    {
        return node?.remarks.TrimEx() ?? string.Empty;
    }

    public string network()
    {
        if (node == null || Misc.IsNullOrEmpty(node.network))
            return Global.DefaultNetwork;
        return node.network.TrimEx();
    }

    public string headerType()
    {
        if (node == null || Misc.IsNullOrEmpty(node.headerType))
            return Global.None;
        return node.headerType.Replace(" ", "").TrimEx();
    }

    public string requestHost()
    {
        if (node == null || Misc.IsNullOrEmpty(node.requestHost))
            return string.Empty;
        return node.requestHost.Replace(" ", "").TrimEx();
    }

    public string path()
    {
        if (node == null || Misc.IsNullOrEmpty(node.path))
            return string.Empty;
        return node.path.Replace(" ", "").TrimEx();
    }

    public string streamSecurity()
    {
        if (node == null || Misc.IsNullOrEmpty(node.streamSecurity))
            return string.Empty;
        return node.streamSecurity.TrimEx();
    }

    public bool allowInsecure()
    {
        if (node == null || Misc.IsNullOrEmpty(node.allowInsecure))
            return defAllowInsecure;
        return Convert.ToBoolean(vmess[index].allowInsecure);
    }

    public int GetLocalPort(string protocol)
    {
        if (protocol == Global.InboundHttp)
            return GetLocalPort(Global.InboundSocks) + 1;
        if (protocol == "speedtest")
            return GetLocalPort(Global.InboundSocks) + 103;

        int localPort = 0;
        foreach (InItem inItem in inbound)
        {
            if (inItem.protocol.Equals(protocol))
            {
                localPort = inItem.localPort;
                break;
            }
        }
        return localPort;
    }

    public int configType()
    {
        return node?.configType ?? 0;
    }

    public string getSummary()
    {
        return node?.getSummary() ?? string.Empty;
    }

    public string getItemId()
    {
        return node?.getItemId() ?? string.Empty;
    }

    public string flow()
    {
        return node?.flow.TrimEx() ?? string.Empty;
    }

    public List<string> alpn()
    {
        if (node == null)
            return null;

        if (Misc.IsNullOrEmpty(node.alpn))
            return null;

        return Misc.String2List(node.alpn);
    }

    public string fingerprint()
    {
        if (node == null)
            return string.Empty;

        if (Misc.IsNullOrEmpty(node.fingerprint))
            return string.Empty;

        return node.fingerprint;
    }
    #endregion
}

[Serializable]
public class ProfileItem
{
    public ProfileItem()
    {
        configVersion = Global.configVersion;
        configType = (int)EConfigType.Vmess;
        address = string.Empty;
        port = 0;
        id = string.Empty;
        alterId = 0;
        security = string.Empty;
        network = string.Empty;
        remarks = string.Empty;
        headerType = string.Empty;
        requestHost = string.Empty;
        path = string.Empty;
        streamSecurity = string.Empty;
        allowInsecure = string.Empty;
        subid = string.Empty;
        flow = string.Empty;
        testResult = string.Empty;
    }

    public string getSummary()
    {
        string summary = string.Format("[{0}] ", ((EConfigType)configType).ToString());
        string[] arrAddr = address.Split('.');
        string addr;
        if (arrAddr.Length > 2)
        {
            addr = $"{arrAddr[0]}***{arrAddr[arrAddr.Length - 1]}";
        }
        else if (arrAddr.Length > 1)
        {
            addr = $"***{arrAddr[arrAddr.Length - 1]}";
        }
        else
        {
            addr = address;
        }
        switch (configType)
        {
            case (int)EConfigType.Vmess:
                summary += string.Format("{0}({1}:{2})", remarks, addr, port);
                break;
            case (int)EConfigType.Shadowsocks:
                summary += string.Format("{0}({1}:{2})", remarks, addr, port);
                break;
            case (int)EConfigType.Socks:
                summary += string.Format("{0}({1}:{2})", remarks, addr, port);
                break;
            case (int)EConfigType.VLESS:
                summary += string.Format("{0}({1}:{2})", remarks, addr, port);
                break;
            case (int)EConfigType.Trojan:
                summary += string.Format("{0}({1}:{2})", remarks, addr, port);
                break;
            default:
                summary += string.Format("{0}", remarks);
                break;
        }
        return summary;
    }

    public string getSubRemarks(V2RayNConfig config)
    {
        string subRemarks = string.Empty;
        if (Misc.IsNullOrEmpty(subid))
        {
            return subRemarks;
        }
        foreach (SubItem sub in config.subItem)
        {
            if (sub.id.EndsWith(subid))
            {
                return sub.remarks;
            }
        }
        if (subid.Length <= 4)
        {
            return subid;
        }
        return subid.Substring(0, 4);
    }

    public string getItemId()
    {
        string itemId = $"{address}{port}{requestHost}{path}";
        itemId = Misc.Base64Encode(itemId);
        return itemId;
    }

    /// <summary>
    /// 版本(现在=2)
    /// </summary>
    public string configVersion { get; set; }

    /// <summary>
    /// 远程服务器地址
    /// </summary>
    public string address { get; set; }

    /// <summary>
    /// 远程服务器端口
    /// </summary>
    public int port { get; set; }

    /// <summary>
    /// 远程服务器ID
    /// </summary>
    public string id { get; set; }

    /// <summary>
    /// 远程服务器额外ID
    /// </summary>
    public int alterId { get; set; }

    /// <summary>
    /// 本地安全策略
    /// </summary>
    public string security { get; set; }

    /// <summary>
    /// tcp,kcp,ws,h2,quic
    /// </summary>
    public string network { get; set; }

    /// <summary>
    /// 备注或别名
    /// </summary>
    public string remarks { get; set; }

    /// <summary>
    /// 伪装类型
    /// </summary>
    public string headerType { get; set; }

    /// <summary>
    /// 伪装的域名
    /// </summary>
    public string requestHost { get; set; }

    /// <summary>
    /// ws h2 path
    /// </summary>
    public string path { get; set; }

    /// <summary>
    /// 底层传输安全
    /// </summary>
    public string streamSecurity { get; set; }

    /// <summary>
    /// 是否允许不安全连接（用于客户端）
    /// </summary>
    public string allowInsecure { get; set; }

    /// <summary>
    /// config type(1=normal,2=custom)
    /// </summary>
    public int configType { get; set; }

    /// <summary>
    ///
    /// </summary>
    public string testResult { get; set; }

    /// <summary>
    /// SubItem id
    /// </summary>
    public string subid { get; set; }
    public bool isSub { get; set; } = true;

    /// <summary>
    /// VLESS flow
    /// </summary>
    public string flow { get; set; }

    /// <summary>
    /// tls sni
    /// </summary>
    public string sni { get; set; }

    /// <summary>
    /// tls alpn
    /// </summary>
    public string alpn { get; set; } = string.Empty;
    public int preSocksPort { get; set; }
    public string fingerprint { get; set; }
    public bool displayLog { get; set; } = true;
    public string publicKey { get; set; }
    public string shortId { get; set; }
    public string spiderX { get; set; }
}

[Serializable]
public class InItem
{
    /// <summary>
    /// 本地监听端口
    /// </summary>
    public int localPort { get; set; }

    /// <summary>
    /// 协议，默认为socks
    /// </summary>
    public string protocol { get; set; }

    /// <summary>
    /// 允许udp
    /// </summary>
    public bool udpEnabled { get; set; }

    /// <summary>
    /// 开启流量探测
    /// </summary>
    public bool sniffingEnabled { get; set; } = true;
}

[Serializable]
public class KcpItem
{
    public int mtu { get; set; }
    public int tti { get; set; }
    public int uplinkCapacity { get; set; }
    public int downlinkCapacity { get; set; }
    public bool congestion { get; set; }
    public int readBufferSize { get; set; }
    public int writeBufferSize { get; set; }
}

[Serializable]
public class SubItem
{
    public string id { get; set; }
    public string remarks { get; set; }
    public string url { get; set; }
    public bool enabled { get; set; } = true;
    public string protocolFilter { get; set; } = "";
}

[Serializable]
public class UIItem
{
    public System.Drawing.Size mainSize { get; set; }
    public Dictionary<string, int> mainLvColWidth { get; set; }
}
