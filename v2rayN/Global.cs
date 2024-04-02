
using System.Collections.Generic;

namespace v2rayN;

class Global
{
    public const string configVersion = "2";

    public const string v2rayWebsiteUrl = @"https://github.com/XTLS/Xray-core";
    public const string AboutUrl = @"https://github.com/blackier/v2rayN";
    public const string UpdateUrl = AboutUrl + @"/releases";

    /// <summary>
    /// SpeedTestUrl
    /// </summary>
    public const string SpeedTestUrl = @"http://cachefly.cachefly.net/10mb.test";
    public const string SpeedPingTestUrl = @"https://www.google.com/generate_204";
    public const string AvailabilityTestUrl = @"https://www.google.com/generate_204";

    /// <summary>
    /// PromotionUrl
    /// </summary>
    public const string PromotionUrl = @"aHR0cHM6Ly85LjIzNDQ1Ni54eXovYWJjLmh0bWw=";

    /// <summary>
    /// 本软件配置文件名
    /// </summary>
    public const string ConfigFileName = "configN.json";

    /// <summary>
    /// v2ray配置文件名
    /// </summary>
    public const string v2rayConfigFileName = "config.json";

    /// <summary>
    /// 默认加密方式
    /// </summary>
    public const string DefaultSecurity = "auto";

    /// <summary>
    /// 默认传输协议
    /// </summary>
    public const string DefaultNetwork = "tcp";

    /// <summary>
    /// Tcp伪装http
    /// </summary>
    public const string TcpHeaderHttp = "http";

    /// <summary>
    /// None值
    /// </summary>
    public const string None = "none";

    /// <summary>
    /// 代理 tag值
    /// </summary>
    public const string agentTag = "proxy";

    /// <summary>
    /// 直连 tag值
    /// </summary>
    public const string directTag = "direct";

    /// <summary>
    /// 阻止 tag值
    /// </summary>
    public const string blockTag = "block";

    public const string StreamSecurity = "tls";

    public const string InboundSocks = "socks";
    public const string InboundHttp = "http";
    public const string Loopback = "127.0.0.1";
    public const string InboundAPITagName = "api";
    public const string InboundAPIProtocal = "dokodemo-door";


    /// <summary>
    /// vmess
    /// </summary>
    public const string vmessProtocol = "vmess://";
    /// <summary>
    /// vmess
    /// </summary>
    public const string vmessProtocolLite = "vmess";
    /// <summary>
    /// shadowsocks
    /// </summary>
    public const string ssProtocol = "ss://";
    /// <summary>
    /// shadowsocks
    /// </summary>
    public const string ssProtocolLite = "shadowsocks";
    /// <summary>
    /// socks
    /// </summary>
    public const string socksProtocol = "socks://";
    /// <summary>
    /// socks
    /// </summary>
    public const string socksProtocolLite = "socks";
    /// <summary>
    /// http
    /// </summary>
    public const string httpProtocol = "http://";
    /// <summary>
    /// https
    /// </summary>
    public const string httpsProtocol = "https://";
    /// <summary>
    /// vless
    /// </summary>
    public const string vlessProtocol = "vless://";
    /// <summary>
    /// vless
    /// </summary>
    public const string vlessProtocolLite = "vless";
    /// <summary>
    /// trojan
    /// </summary>
    public const string trojanProtocol = "trojan://";
    /// <summary>
    /// trojan
    /// </summary>
    public const string trojanProtocolLite = "trojan";

    /// <summary>
    /// email
    /// </summary>
    public const string userEMail = "t@t.tt";

    /// <summary>
    /// MyRegPath
    /// </summary>
    public const string MyRegPath = "Software\\v2rayNGUI";

    /// <summary>
    /// Language
    /// </summary>
    public const string MyRegKeyLanguage = "CurrentLanguage";
    /// <summary>
    /// Icon
    /// </summary>
    public const string CustomIconName = "v2rayN.ico";

    public enum StatisticsFreshRate
    {
        quick = 1000,
        medium = 2000,
        slow = 3000
    }
    public const string StatisticLogOverall = "StatisticLogOverall.json";

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
    /// 常见私有ip和域名
    /// </summary>
    public static readonly string[] geoPrivateAdress = { "geoip:private" };

    /// <summary>
    /// 所有预设路由规则
    /// </summary>
    public static readonly List<string[]> presetRoutingRules = new()
    {
        geoPrivateAdress,
        geoCnAdress,
        geoNoCnAdress,
        geoAdAdress
    };

    /// <summary>
    /// 是否需要重启服务V2ray
    /// </summary>
    public static bool reloadV2ray
    {
        get; set;
    }

    public static readonly int v2rayApiPort = Misc.GetFreePort();

    public static System.Threading.Mutex mutexObj
    {
        get; set;
    }
}
