using System.Collections.Generic;

namespace Shadowsocks.Interop.V2Ray.Transport;

public class GRPCObject
{
    public string Authority { get; set; }
    public string ServiceName { get; set; }
    public bool? MultiMode { get; set; }
    public string user_agent { get; set; }
    public int? idle_timeout { get; set; }
    public int? health_check_timeout { get; set; }
    public bool? permit_without_stream { get; set; }
    public int? initial_windows_size { get; set; }

    public GRPCObject()
    {
        idle_timeout = 60;
        health_check_timeout = 20;
        permit_without_stream = false;
        initial_windows_size = 0;
    }
}
