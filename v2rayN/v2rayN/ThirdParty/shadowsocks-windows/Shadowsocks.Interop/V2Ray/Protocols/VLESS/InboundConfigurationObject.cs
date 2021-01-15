using System.Collections.Generic;

namespace Shadowsocks.Interop.V2Ray.Protocols.VLESS
{
    public class InboundConfigurationObject
    {
        public List<UserObject> Clients { get; set; }
        public string Decryption { get; set; }
        public List<FallbackObject> Fallbacks { get; set; }

        public InboundConfigurationObject()
        {
            Clients = new();
            Decryption = "none";
        }
    }
}
