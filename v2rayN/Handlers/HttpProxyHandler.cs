using System;
using v2rayN.Config;

using Shadowsocks.WPF.Services.SystemProxy;

namespace v2rayN.Handlers;

/// <summary>
/// 系统代理(http)模式
/// </summary>
public enum ListenerType
{        
    closeSystemProxy = 0,
    openSystemProxy
}
/// <summary>
/// 系统代理(http)总处理
/// </summary>
class HttpProxyHandler
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
                case ListenerType.openSystemProxy:
                    WinINet.ProxyGlobal($"{Global.Loopback}:{port}", string.Empty);
                    break;
                default:
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
