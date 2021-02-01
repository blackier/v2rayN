using System.Collections.Generic;
using System.Reflection;
using System.Resources;

namespace v2rayN
{
    partial class Utils
    {
        public class StringsRes
        {
            private static ResourceManager res = new ResourceManager("v2rayN.Localization.Strings", Assembly.GetExecutingAssembly());

            private static string LoadString(ResourceManager resMgr, string key)
            {
                string value = resMgr.GetString(key);
                if (value == null)
                {
                    throw new KeyNotFoundException($"key: {key}");
                }
                return value;
            }

            public static string I18N(string key)
            {
                return LoadString(res, key);
            }
        }
    }
}
