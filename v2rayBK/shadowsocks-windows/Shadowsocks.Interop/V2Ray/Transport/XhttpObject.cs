using System.Collections.Generic;

namespace Shadowsocks.Interop.V2Ray.Transport;

public class XhttpObject
{
    public string Host { get; set; }
    public string Path { get; set; }
    public string Mode { get; set; }
    public object Extra { get; set; }

    public XhttpObject()
    {
        Path = "/";
        Mode = "auto";
    }
}
