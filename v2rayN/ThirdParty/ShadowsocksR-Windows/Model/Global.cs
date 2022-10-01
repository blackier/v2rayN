using Shadowsocks.Controller;
using Shadowsocks.Controller.Service;
using Shadowsocks.Util;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;

namespace Shadowsocks.Model
{
    public static class Global
    {
        public static bool OSSupportsLocalIPv6 => Socket.OSSupportsIPv6;

        public static string LocalHost => OSSupportsLocalIPv6 ? $@"[{IPAddress.IPv6Loopback}]" : $@"{IPAddress.Loopback}";

        public static string AnyHost => OSSupportsLocalIPv6 ? $@"[{IPAddress.IPv6Any}]" : $@"{IPAddress.Any}";

        public static IPAddress IpLocal => OSSupportsLocalIPv6 ? IPAddress.IPv6Loopback : IPAddress.Loopback;

        public static IPAddress IpAny => OSSupportsLocalIPv6 ? IPAddress.IPv6Any : IPAddress.Any;

        public static Configuration GuiConfig;

        public static MainController Controller;
    }
}
