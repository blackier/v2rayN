﻿using System;
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
                        config.HttpProxyRuleEnable ? config.HttpProxyRule : string.Empty
                    );
                    App.PostLog("Systeam http proxy start");
                    break;
                case SystemProxyType.Socks:
                    string pacUrl = "http://127.0.0.1:8008/pac/";
                    PACHandler.StartListener(new[] { pacUrl });
                    WinINet.ProxyPAC(pacUrl + "socks.pac");
                    App.PostLog("Systeam pac proxy start");
                    break;
                default:
                    PACHandler.StopListenner();
                    WinINet.Reset();
                    App.PostLog("Systeam proxy stop");
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
