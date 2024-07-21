using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using v2rayN.Config;

namespace v2rayN.Handlers.Fmt;

internal class VmessFmt : BaseFmt
{
    public static ProfileItem? Resolve(string str, out string msg)
    {
        msg = StringsRes.I18N("ConfigurationFormatIncorrect");
        ProfileItem? item;
        if (str.IndexOf('?') > 0 && str.IndexOf('&') > 0)
        {
            item = ResolveStdVmess(str);
        }
        else
        {
            item = ResolveVmess(str, out msg);
        }
        return item;
    }

    public static string? ToUri(ProfileItem? item)
    {
        if (item == null)
            return null;
        string url = string.Empty;

        VmessQRCode vmessQRCode =
            new()
            {
                v = item.configVersion,
                ps = item.remarks.TrimEx(),
                add = item.address,
                port = item.port,
                id = item.id,
                aid = item.alterId,
                scy = item.security,
                net = item.network,
                type = item.headerType,
                host = item.requestHost,
                path = item.path,
                tls = item.streamSecurity,
                sni = item.sni,
                alpn = item.alpn,
                fp = item.fingerprint
            };

        url = Json.ToJson(vmessQRCode);
        url = Misc.Base64Encode(url);
        url = $"{Global.ProtocolShares[EConfigType.VMess]}{url}";

        return url;
    }

    private static ProfileItem? ResolveVmess(string result, out string msg)
    {
        msg = string.Empty;
        var item = new ProfileItem { configType = EConfigType.VMess };

        result = result[Global.ProtocolShares[EConfigType.VMess].Length..];
        result = Misc.Base64Decode(result);

        //转成Json
        VmessQRCode? vmessQRCode = Json.FromJson<VmessQRCode>(result);
        if (vmessQRCode == null)
        {
            return null;
        }

        item.network = Global.DefaultNetwork;
        item.headerType = Global.None;

        item.configVersion = Misc.ToString(vmessQRCode.v);
        item.remarks = Misc.ToString(vmessQRCode.ps);
        item.address = Misc.ToString(vmessQRCode.add);
        item.port = Misc.ToInt(vmessQRCode.port);
        item.id = Misc.ToString(vmessQRCode.id);
        item.alterId = Misc.ToInt(vmessQRCode.aid);
        item.security = Misc.ToString(vmessQRCode.scy);

        item.security = !Misc.IsNullOrEmpty(vmessQRCode.scy) ? vmessQRCode.scy : Global.DefaultSecurity;
        if (!Misc.IsNullOrEmpty(vmessQRCode.net))
        {
            item.network = vmessQRCode.net;
        }
        if (!Misc.IsNullOrEmpty(vmessQRCode.type))
        {
            item.headerType = vmessQRCode.type;
        }

        item.requestHost = Misc.ToString(vmessQRCode.host);
        item.path = Misc.ToString(vmessQRCode.path);
        item.streamSecurity = Misc.ToString(vmessQRCode.tls);
        item.sni = Misc.ToString(vmessQRCode.sni);
        item.alpn = Misc.ToString(vmessQRCode.alpn);
        item.fingerprint = Misc.ToString(vmessQRCode.fp);

        return item;
    }

    public static ProfileItem? ResolveStdVmess(string str)
    {
        ProfileItem item = new() { configType = EConfigType.VMess, security = "auto" };

        Uri url = new(str);

        item.address = url.IdnHost;
        item.port = url.Port;
        item.remarks = url.GetComponents(UriComponents.Fragment, UriFormat.Unescaped);
        item.id = Misc.UrlDecode(url.UserInfo);

        var query = Misc.ParseQueryString(url.Query);
        ResolveStdTransport(query, ref item);

        return item;
    }
}
