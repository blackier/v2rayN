namespace Shadowsocks.Interop.V2Ray.Protocols.VLESS
{
    public class FallbackObject
    {
        public string Alpn { get; set; }
        public string Path { get; set; }
        public object Dest { get; set; }
        public int? Xver { get; set; }

        public FallbackObject()
        {
            Dest = 80;
        }
    }
}
