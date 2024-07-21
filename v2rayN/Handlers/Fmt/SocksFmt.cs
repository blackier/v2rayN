﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using v2rayN.Config;

namespace v2rayN.Handlers.Fmt;

internal class SocksFmt : BaseFmt
{
    public static ProfileItem? Resolve(string str, out string msg)
    {
        msg = StringsRes.I18N("ConfigurationFormatIncorrect");
        ProfileItem? item;

        item = ResolveSocksNew(str) ?? ResolveSocks(str);
        if (item == null)
        {
            return null;
        }
        if (item.address.Length == 0 || item.port == 0)
        {
            return null;
        }

        item.configType = EConfigType.Socks;

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
        //url = string.Format("{0}:{1}@{2}:{3}",
        //    item.security,
        //    item.id,
        //    item.address,
        //    item.port);
        //url = Utile.Base64Encode(url);
        //new
        var pw = Misc.Base64Encode($"{item.security}:{item.id}");
        url = $"{pw}@{GetIpv6(item.address)}:{item.port}";
        url = $"{Global.ProtocolShares[EConfigType.Socks]}{url}{remark}";
        return url;
    }

    private static ProfileItem? ResolveSocks(string result)
    {
        ProfileItem item = new() { configType = EConfigType.Socks };
        result = result[Global.ProtocolShares[EConfigType.Socks].Length..];
        //remark
        int indexRemark = result.IndexOf("#");
        if (indexRemark > 0)
        {
            try
            {
                item.remarks = Misc.UrlDecode(result.Substring(indexRemark + 1, result.Length - indexRemark - 1));
            }
            catch { }
            result = result[..indexRemark];
        }
        //part decode
        int indexS = result.IndexOf("@");
        if (indexS > 0) { }
        else
        {
            result = Misc.Base64Decode(result);
        }

        string[] arr1 = result.Split('@');
        if (arr1.Length != 2)
        {
            return null;
        }
        string[] arr21 = arr1[0].Split(':');
        //string[] arr22 = arr1[1].Split(':');
        int indexPort = arr1[1].LastIndexOf(":");
        if (arr21.Length != 2 || indexPort < 0)
        {
            return null;
        }
        item.address = arr1[1][..indexPort];
        item.port = Misc.ToInt(arr1[1][(indexPort + 1)..]);
        item.security = arr21[0];
        item.id = arr21[1];

        return item;
    }

    private static ProfileItem? ResolveSocksNew(string result)
    {
        Uri parsedUrl;
        try
        {
            parsedUrl = new Uri(result);
        }
        catch (UriFormatException)
        {
            return null;
        }
        ProfileItem item =
            new()
            {
                remarks = parsedUrl.GetComponents(UriComponents.Fragment, UriFormat.Unescaped),
                address = parsedUrl.IdnHost,
                port = parsedUrl.Port,
            };

        // parse base64 UserInfo
        string rawUserInfo = parsedUrl.GetComponents(UriComponents.UserInfo, UriFormat.Unescaped);
        string userInfo = Misc.Base64Decode(rawUserInfo);
        string[] userInfoParts = userInfo.Split(new[] { ':' }, 2);
        if (userInfoParts.Length == 2)
        {
            item.security = userInfoParts[0];
            item.id = userInfoParts[1];
        }

        return item;
    }
}
