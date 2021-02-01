namespace Shadowsocks.Interop.V2Ray.Protocols.Blackhole
{
    public class OutboundConfigurationObject
    {
        public ResponseObject Response { get; set; }

        public OutboundConfigurationObject(string type = "none")
        {
            Response = new(type);
        }
    }
}
