using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using v2rayN.Config;

namespace v2rayN.Handlers.Fmt;

internal class FmtHandler
{
    public static string? GetShareUri(ProfileItem item)
    {
        try
        {
            var url = item.configType switch
            {
                EConfigType.VMess => VmessFmt.ToUri(item),
                EConfigType.Shadowsocks => ShadowsocksFmt.ToUri(item),
                EConfigType.Socks => SocksFmt.ToUri(item),
                EConfigType.Trojan => TrojanFmt.ToUri(item),
                EConfigType.VLESS => VLESSFmt.ToUri(item),
                EConfigType.Tuic => TuicFmt.ToUri(item),
                EConfigType.Wireguard => WireguardFmt.ToUri(item),
                _ => null,
            };

            return url;
        }
        catch (Exception ex)
        {
            Log.SaveLog(ex.Message, ex);
            return "";
        }
    }

    public static ProfileItem? ResolveConfig(string config, out string msg)
    {
        msg = StringsRes.I18N("ConfigurationFormatIncorrect");

        try
        {
            string str = config.TrimEx();
            if (Misc.IsNullOrEmpty(str))
            {
                msg = StringsRes.I18N("FailedReadConfiguration");
                return null;
            }

            if (str.StartsWith(Global.ProtocolShares[EConfigType.VMess]))
            {
                return VmessFmt.Resolve(str, out msg);
            }
            else if (str.StartsWith(Global.ProtocolShares[EConfigType.Shadowsocks]))
            {
                return ShadowsocksFmt.Resolve(str, out msg);
            }
            else if (str.StartsWith(Global.ProtocolShares[EConfigType.Socks]))
            {
                return SocksFmt.Resolve(str, out msg);
            }
            else if (str.StartsWith(Global.ProtocolShares[EConfigType.Trojan]))
            {
                return TrojanFmt.Resolve(str, out msg);
            }
            else if (str.StartsWith(Global.ProtocolShares[EConfigType.VLESS]))
            {
                return VLESSFmt.Resolve(str, out msg);
            }
            else if (str.StartsWith(Global.ProtocolShares[EConfigType.Tuic]))
            {
                return TuicFmt.Resolve(str, out msg);
            }
            else if (str.StartsWith(Global.ProtocolShares[EConfigType.Wireguard]))
            {
                return WireguardFmt.Resolve(str, out msg);
            }
            else
            {
                msg = StringsRes.I18N("NonvmessOrssProtocol");
                return null;
            }
        }
        catch (Exception ex)
        {
            Log.SaveLog(ex.Message, ex);
            msg = StringsRes.I18N("Incorrectconfiguration");
            return null;
        }
    }
}
