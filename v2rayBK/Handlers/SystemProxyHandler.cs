using System;
using Shadowsocks.WPF.Services.SystemProxy;
using v2rayBK.ViewModels;

namespace v2rayBK.Handlers;

/// <summary>
/// 系统代理(http)模式
/// </summary>
public enum SystemProxyType
{
    Close = 0,
    Http,
    Socks
}

/// <summary>
/// 系统代理(http)总处理
/// </summary>
public class SystemProxyHandler
{
    public static bool Update(v2rayBKConfig config)
    {
        try
        {
            switch (config.SystemProxyType)
            {
                case SystemProxyType.Http:
                    PACHandler.StopListenner();
                    WinINet.ProxyGlobal(
                        $"{Global.Loopback}:{config.HttpInboundPort}",
                        config.UserDirectSkipEnable ? config.UserDirectSkip : string.Empty
                    );
                    break;
                case SystemProxyType.Socks:
                    string pacUrl = "http://127.0.0.1:8008/pac/";
                    PACHandler.StartListener(new[] { pacUrl });
                    WinINet.ProxyPAC(pacUrl + "socks.pac");
                    break;
                default:
                    PACHandler.StopListenner();
                    WinINet.Reset();
                    break;
            }
        }
        catch (Exception ex)
        {
            App.PostLog(ex.Message);
        }
        return true;
    }
}
