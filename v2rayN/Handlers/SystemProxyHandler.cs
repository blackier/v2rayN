using System;
using Shadowsocks.WPF.Services.SystemProxy;
using v2rayN.Config;

namespace v2rayN.Handlers;

/// <summary>
/// 系统代理(http)模式
/// </summary>
public enum ListenerType
{
    closeSystemProxy = 0,
    openSystemProxyHttp,
    openSystemProxySocks
}

/// <summary>
/// 系统代理(http)总处理
/// </summary>
class SystemProxyHandler
{
    public static bool Update(Config.V2RayNConfig config)
    {
        try
        {
            int port = config.GetLocalPort(Global.InboundHttp);
            if (port <= 0)
            {
                return false;
            }

            switch (config.listenerType)
            {
                case ListenerType.openSystemProxyHttp:
                    PACHandler.StopListenner();
                    WinINet.ProxyGlobal($"{Global.Loopback}:{port}", string.Empty);
                    break;
                case ListenerType.openSystemProxySocks:
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
            Log.SaveLog(ex.Message, ex);
        }
        return true;
    }
}
