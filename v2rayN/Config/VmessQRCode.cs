using System;
using System.Text.Json.Serialization;

namespace v2rayN.Config;

[Serializable]
class VmessQRCode
{
    /// <summary>
    /// 版本
    /// </summary>
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public object v { get; set; } = null;

    /// <summary>
    /// 备注
    /// </summary>
    public string ps { get; set; } = string.Empty;

    /// <summary>
    /// 远程服务器地址
    /// </summary>
    public string add { get; set; } = string.Empty;

    /// <summary>
    /// 远程服务器端口
    /// </summary>
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public int port { get; set; } = 0;

    /// <summary>
    /// 远程服务器ID
    /// </summary>
    public string id { get; set; } = string.Empty;

    /// <summary>
    /// 远程服务器额外ID
    /// </summary>
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public int aid { get; set; } = 0;

    public string scy { get; set; } = string.Empty;

    /// <summary>
    /// 传输协议tcp,kcp,ws
    /// </summary>
    public string net { get; set; } = string.Empty;

    /// <summary>
    /// 伪装类型
    /// </summary>
    public string type { get; set; } = string.Empty;

    /// <summary>
    /// 伪装的域名
    /// </summary>
    public string host { get; set; } = string.Empty;

    /// <summary>
    /// path
    /// </summary>
    public string path { get; set; } = string.Empty;

    /// <summary>
    /// 底层传输安全
    /// </summary>
    public string tls { get; set; } = string.Empty;

    public string sni { get; set; } = string.Empty;

    public string alpn { get; set; } = string.Empty;

    public string fp { get; set; } = string.Empty;
}
