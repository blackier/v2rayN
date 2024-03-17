using System.Collections.Generic;
using System.Reflection;
using System.Resources;

namespace v2rayN.Utils;

public class StringsRes
{
    private static I18N _i18n = new I18N_zh_Hans();

    public static string I18N(string key)
    {
        return _i18n.GetString(key);
    }
}
