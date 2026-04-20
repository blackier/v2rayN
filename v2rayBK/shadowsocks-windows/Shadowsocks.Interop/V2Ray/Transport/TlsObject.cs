using System.Collections.Generic;

namespace Shadowsocks.Interop.V2Ray.Transport
{
    public class TlsObject
    {
        public string ServerName { get; set; }
        // "allowInsecure" will be removed automatically after 2026-06-01,
        // please use "pinnedPeerCertSha256"(pcs) and "verifyPeerCertByName"(vcn) instead,
        // PLEASE CONTACT YOUR SERVICE PROVIDER (AIRPORT)
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
