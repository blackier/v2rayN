using System.Collections.Generic;

namespace v2rayBK;

public enum OpenUrlType
{
    XRayProject,
    v2rayBK,
    Promotion,
}

class GlobalEx
{
    public const string XRayProjectUrl = "https://github.com/XTLS/Xray-core";
    public const string v2rayBKUrl = "https://github.com/blackier/v2rayN";
    public const string PromotionUrl = "aHR0cHM6Ly85LjIzNDQ1Ni54eXovYWJjLmh0bWw=";

    public static readonly List<string> DomainDNSAddress = ["223.5.5.5", "223.6.6.6", "localhost"];
    public static readonly List<string> DomainOverseaDNSAddress = ["1.1.1.1", "8.8.8.8"];

    /// <summary>
    /// 本软件配置文件名
    /// </summary>
    public const string ConfigFileName = "configBK.json";

    /// <summary>
    /// v2ray配置文件名
    /// </summary>
    public const string v2rayConfigFileName = "config.json";

    public const string dnsServerTag = "dns-server";
    public const string dnsInTag = "dns-int";
    public const string dnsOutTag = "dns-out";
    public const int dnsPort = 53;

    public static readonly int v2rayApiPort = Utils.GetFreePort();

    /// <summary>
    /// 大陆常用ip和域名
    /// </summary>
    public static readonly string[] geoCnAdress = { "geoip:cn", "geosite:cn" };

    /// <summary>
    /// 大陆外常用ip和域名
    /// </summary>
    public static readonly string[] geoNoCnAdress = { "geosite:geolocation-!cn" };

    /// <summary>
    /// 常见广告地址
    /// </summary>
    public static readonly string[] geoAdAdress = { "geosite:category-ads-all" };

    /// <summary>
    /// 常见私有ip
    /// </summary>
    public static readonly string[] geoPrivateAdress = { "geoip:private" };
}
