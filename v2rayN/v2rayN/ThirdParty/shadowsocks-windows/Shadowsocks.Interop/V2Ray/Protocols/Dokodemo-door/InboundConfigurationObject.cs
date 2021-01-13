using System.Collections.Generic;

namespace Shadowsocks.Interop.V2Ray.Protocols.Dokodemo_door
{
    public class InboundConfigurationObject
    {
        public string? Address { get; set; }
        public int? Port { get; set; }
        public string? Network { get; set; }
        public int? Timeout { get; set; }
        public bool? FollowRedirect { get; set; }
        public int? UserLevel { get; set; }

        public InboundConfigurationObject(string address, string network)
        {
            Address = address;
            Network = network;
        }
    }
}
