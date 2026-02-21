using System.Collections.Generic;

namespace Shadowsocks.Interop.V2Ray.Transport
{
    public class TlsObject
    {
        public string ServerName { get; set; }
        public bool AllowInsecure { get; set; }
        public List<string> Alpn { get; set; }
        public List<CertificateObject> Certificates { get; set; }
        public bool DisableSystemRoot { get; set; }
        public string Fingerprint { get; set; }
        public string PinnedPeerCertSha256 { get; set; }
        public string EchConfigList { get; set; }
        public string EchForceQuery { get; set; }
    }
}
