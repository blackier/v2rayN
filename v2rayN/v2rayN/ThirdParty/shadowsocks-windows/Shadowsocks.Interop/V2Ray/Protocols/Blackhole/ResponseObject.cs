namespace Shadowsocks.Interop.V2Ray.Protocols.Blackhole
{
    public class ResponseObject
    {
        public string Type { get; set; }

        public ResponseObject(string type = "none")
        {
            Type = type;
        }
    }
}
