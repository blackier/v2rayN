using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using v2rayN.Config;

namespace v2rayN.Handlers.Fmt;

internal class WireguardFmt : BaseFmt
{
    public static ProfileItem? Resolve(string str, out string msg)
    {
        msg = StringsRes.I18N("ConfigurationFormatIncorrect");

        ProfileItem item = new() { configType = EConfigType.Wireguard };

        Uri url = new(str);

        item.address = url.IdnHost;
        item.port = url.Port;
        item.remarks = url.GetComponents(UriComponents.Fragment, UriFormat.Unescaped);
        item.id = Misc.UrlDecode(url.UserInfo);

        var query = Misc.ParseQueryString(url.Query);

        item.publicKey = Misc.UrlDecode(query["publickey"] ?? "");
        item.path = Misc.UrlDecode(query["reserved"] ?? "");
        item.requestHost = Misc.UrlDecode(query["address"] ?? "");
        item.shortId = Misc.UrlDecode(query["mtu"] ?? "");

        return item;
    }

    public static string? ToUri(ProfileItem? item)
    {
        if (item == null)
            return null;
        string url = string.Empty;

        string remark = string.Empty;
        if (!Misc.IsNullOrEmpty(item.remarks))
        {
            remark = "#" + Misc.UrlEncode(item.remarks);
        }

        var dicQuery = new Dictionary<string, string>();
        if (!Misc.IsNullOrEmpty(item.publicKey))
        {
            dicQuery.Add("publickey", Misc.UrlEncode(item.publicKey));
        }
        if (!Misc.IsNullOrEmpty(item.path))
        {
            dicQuery.Add("reserved", Misc.UrlEncode(item.path));
        }
        if (!Misc.IsNullOrEmpty(item.requestHost))
        {
            dicQuery.Add("address", Misc.UrlEncode(item.requestHost));
        }
        if (!Misc.IsNullOrEmpty(item.shortId))
        {
            dicQuery.Add("mtu", Misc.UrlEncode(item.shortId));
        }
        string query = "?" + string.Join("&", dicQuery.Select(x => x.Key + "=" + x.Value).ToArray());

        url = string.Format("{0}@{1}:{2}", Misc.UrlEncode(item.id), GetIpv6(item.address), item.port);
        url = $"{Global.ProtocolShares[EConfigType.Wireguard]}{url}/{query}{remark}";
        return url;
    }
}
