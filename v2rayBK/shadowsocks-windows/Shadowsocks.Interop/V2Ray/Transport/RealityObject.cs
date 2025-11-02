using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shadowsocks.Interop.V2Ray.Transport;

public class RealityObject
{
    public string ServerName { get; set; }
    public string Fingerprint { get; set; }
    public string ShortId { get; set; }
    public string Password { get; set; }
    public string Mldsa65Verify { get; set; }
    public string SpiderX { get; set; }
}
