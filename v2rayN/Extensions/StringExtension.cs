using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace v2rayN.Extensions;

static class StringExtension
{
    public static bool IsNullOrEmpty(this string value)
    {
        return string.IsNullOrEmpty(value);
    }

    public static string TrimEx(this string value)
    {
        return value == null ? string.Empty : value.Trim();
    }
}
