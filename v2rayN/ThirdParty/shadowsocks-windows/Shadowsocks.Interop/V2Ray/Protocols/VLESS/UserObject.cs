using System;

namespace Shadowsocks.Interop.V2Ray.Protocols.VLESS
{
    /// <summary>
    /// The user object for VLESS AEAD.
    /// </summary>
    public class UserObject
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public int? Level { get; set; }
        public string Encryption { get; set; }
        public string Flow { get; set; }

        public UserObject(string id = "", string encryption = "none")
        {
            Id = id;
            Encryption = encryption;
        }

        public static UserObject Default => new()
        {
            Id = new Guid().ToString(),
            Encryption = "none"
        };
    }
}
