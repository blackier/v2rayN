using System;
using System.Collections.Generic;
using System.Text;

namespace Shadowsocks.Interop.V2Ray.Protocols.TUN
{
    public class InboundConfigurationObject
    {
        public string Name { get; set; }
        public int Mtu { get; set; }
        public List<string> Gateway { get; set; }
        public List<string> Dns { get; set; }
        public int? UserLevel { get; set; }
        public List<string> AutoSystemRoutingTable { get; set; }
        public string AutoOutboundsInterface { get; set; }

        public static InboundConfigurationObject Default =>
            new()
            {
                Name = "xray_tun",
                Mtu = 1500,
                Gateway = ["172.16.0.1/30", "fd00::1/126"],
                Dns =
                [
                    "223.5.5.5",
                    "1.1.1.1"
                    // "2606:4700:4700::1111",
                    // "2001:4860:4860::8888"
                ],
                UserLevel = 0,
                AutoSystemRoutingTable = ["0.0.0.0/0", "::/0"],
                AutoOutboundsInterface = "auto"
            };
    }
}
