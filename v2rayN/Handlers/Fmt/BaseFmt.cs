using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using v2rayN.Config;

namespace v2rayN.Handlers.Fmt;

internal class BaseFmt
{
    protected static string GetIpv6(string address)
    {
        if (Misc.IsIpv6(address))
        {
            // 检查地址是否已经被方括号包围，如果没有，则添加方括号
            return address.StartsWith('[') && address.EndsWith(']') ? address : $"[{address}]";
        }
        return address; // 如果不是IPv6地址，直接返回原地址
    }

    protected static int GetStdTransport(ProfileItem item, string? securityDef, ref Dictionary<string, string> dicQuery)
    {
        if (!Misc.IsNullOrEmpty(item.flow))
        {
            dicQuery.Add("flow", item.flow);
        }

        if (!Misc.IsNullOrEmpty(item.streamSecurity))
        {
            dicQuery.Add("security", item.streamSecurity);
        }
        else
        {
            if (securityDef != null)
            {
                dicQuery.Add("security", securityDef);
            }
        }
        if (!Misc.IsNullOrEmpty(item.sni))
        {
            dicQuery.Add("sni", item.sni);
        }
        if (!Misc.IsNullOrEmpty(item.alpn))
        {
            dicQuery.Add("alpn", Misc.UrlEncode(item.alpn));
        }
        if (!Misc.IsNullOrEmpty(item.fingerprint))
        {
            dicQuery.Add("fp", Misc.UrlEncode(item.fingerprint));
        }
        if (!Misc.IsNullOrEmpty(item.publicKey))
        {
            dicQuery.Add("pbk", Misc.UrlEncode(item.publicKey));
        }
        if (!Misc.IsNullOrEmpty(item.shortId))
        {
            dicQuery.Add("sid", Misc.UrlEncode(item.shortId));
        }
        if (!Misc.IsNullOrEmpty(item.spiderX))
        {
            dicQuery.Add("spx", Misc.UrlEncode(item.spiderX));
        }
        if (item.allowInsecure.Equals("true"))
        {
            dicQuery.Add("allowInsecure", "1");
        }

        dicQuery.Add("type", !Misc.IsNullOrEmpty(item.network) ? item.network : nameof(ETransport.tcp));

        switch (item.network)
        {
            case nameof(ETransport.tcp):
                dicQuery.Add("headerType", !Misc.IsNullOrEmpty(item.headerType) ? item.headerType : Global.None);
                if (!Misc.IsNullOrEmpty(item.requestHost))
                {
                    dicQuery.Add("host", Misc.UrlEncode(item.requestHost));
                }
                break;

            case nameof(ETransport.kcp):
                dicQuery.Add("headerType", !Misc.IsNullOrEmpty(item.headerType) ? item.headerType : Global.None);
                if (!Misc.IsNullOrEmpty(item.path))
                {
                    dicQuery.Add("seed", Misc.UrlEncode(item.path));
                }
                break;

            case nameof(ETransport.ws):
            case nameof(ETransport.httpupgrade):
            case nameof(ETransport.splithttp):
                if (!Misc.IsNullOrEmpty(item.requestHost))
                {
                    dicQuery.Add("host", Misc.UrlEncode(item.requestHost));
                }
                if (!Misc.IsNullOrEmpty(item.path))
                {
                    dicQuery.Add("path", Misc.UrlEncode(item.path));
                }
                break;

            case nameof(ETransport.http):
            case nameof(ETransport.h2):
                dicQuery["type"] = nameof(ETransport.http);
                if (!Misc.IsNullOrEmpty(item.requestHost))
                {
                    dicQuery.Add("host", Misc.UrlEncode(item.requestHost));
                }
                if (!Misc.IsNullOrEmpty(item.path))
                {
                    dicQuery.Add("path", Misc.UrlEncode(item.path));
                }
                break;

            case nameof(ETransport.quic):
                dicQuery.Add("headerType", !Misc.IsNullOrEmpty(item.headerType) ? item.headerType : Global.None);
                dicQuery.Add("quicSecurity", Misc.UrlEncode(item.requestHost));
                dicQuery.Add("key", Misc.UrlEncode(item.path));
                break;

            case nameof(ETransport.grpc):
                if (!Misc.IsNullOrEmpty(item.path))
                {
                    dicQuery.Add("authority", Misc.UrlEncode(item.requestHost));
                    dicQuery.Add("serviceName", Misc.UrlEncode(item.path));
                    if (item.headerType is Global.GrpcGunMode or Global.GrpcMultiMode)
                    {
                        dicQuery.Add("mode", Misc.UrlEncode(item.headerType));
                    }
                }
                break;
        }
        return 0;
    }

    protected static int ResolveStdTransport(NameValueCollection query, ref ProfileItem item)
    {
        item.flow = query["flow"] ?? "";
        item.streamSecurity = query["security"] ?? "";
        item.sni = query["sni"] ?? "";
        item.alpn = Misc.UrlDecode(query["alpn"] ?? "");
        item.fingerprint = Misc.UrlDecode(query["fp"] ?? "");
        item.publicKey = Misc.UrlDecode(query["pbk"] ?? "");
        item.shortId = Misc.UrlDecode(query["sid"] ?? "");
        item.spiderX = Misc.UrlDecode(query["spx"] ?? "");
        item.allowInsecure = (query["allowInsecure"] ?? "") == "1" ? "true" : "";

        item.network = query["type"] ?? nameof(ETransport.tcp);
        switch (item.network)
        {
            case nameof(ETransport.tcp):
                item.headerType = query["headerType"] ?? Global.None;
                item.requestHost = Misc.UrlDecode(query["host"] ?? "");

                break;

            case nameof(ETransport.kcp):
                item.headerType = query["headerType"] ?? Global.None;
                item.path = Misc.UrlDecode(query["seed"] ?? "");
                break;

            case nameof(ETransport.ws):
            case nameof(ETransport.httpupgrade):
            case nameof(ETransport.splithttp):
                item.requestHost = Misc.UrlDecode(query["host"] ?? "");
                item.path = Misc.UrlDecode(query["path"] ?? "/");
                break;

            case nameof(ETransport.http):
            case nameof(ETransport.h2):
                item.network = nameof(ETransport.h2);
                item.requestHost = Misc.UrlDecode(query["host"] ?? "");
                item.path = Misc.UrlDecode(query["path"] ?? "/");
                break;

            case nameof(ETransport.quic):
                item.headerType = query["headerType"] ?? Global.None;
                item.requestHost = query["quicSecurity"] ?? Global.None;
                item.path = Misc.UrlDecode(query["key"] ?? "");
                break;

            case nameof(ETransport.grpc):
                item.requestHost = Misc.UrlDecode(query["authority"] ?? "");
                item.path = Misc.UrlDecode(query["serviceName"] ?? "");
                item.headerType = Misc.UrlDecode(query["mode"] ?? Global.GrpcGunMode);
                break;

            default:
                break;
        }
        return 0;
    }

    protected static bool Contains(string str, params string[] s)
    {
        foreach (var item in s)
        {
            if (str.Contains(item, StringComparison.OrdinalIgnoreCase))
                return true;
        }
        return false;
    }

    protected static string WriteAllText(string strData, string ext = "json")
    {
        var fileName = Misc.GetTempPath($"{Misc.GetGUID(false)}.{ext}");
        File.WriteAllText(fileName, strData);
        return fileName;
    }
}
