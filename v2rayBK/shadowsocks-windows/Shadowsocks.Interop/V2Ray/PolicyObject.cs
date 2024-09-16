using System.Collections.Generic;
using Shadowsocks.Interop.V2Ray.Policy;

namespace Shadowsocks.Interop.V2Ray
{
    public class PolicyObject
    {
        public Dictionary<string, LevelPolicyObject> Levels { get; set; }
        public SystemPolicyObject System { get; set; }

        /// <summary>
        /// Gets the default policy object.
        /// </summary>
        public static PolicyObject Default => new() { Levels = new(), System = SystemPolicyObject.Default, };
    }
}
