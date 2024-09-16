using System.Collections.Generic;

namespace Shadowsocks.Interop.V2Ray.Protocols.VLESS
{
    public class OutboundConfigurationObject
    {
        public List<ServerObject> Vnext { get; set; }

        public OutboundConfigurationObject()
        {
            Vnext = new();
        }

        public OutboundConfigurationObject(string address, int port, string id)
        {
            Vnext = new() { new(address, port, id), };
        }
    }
}
