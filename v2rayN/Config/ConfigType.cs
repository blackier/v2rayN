using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace v2rayN.Config;

public enum EConfigType
{
    VMess = 1,
    Custom = 2,
    Shadowsocks = 3,
    Socks = 4,
    VLESS = 5,
    Trojan = 6,
    Hysteria2 = 7,
    Tuic = 8,
    Wireguard = 9,
    Http = 10
}

public enum EMove
{
    Top = 1,
    Up = 2,
    Down = 3,
    Bottom = 4
}

public enum EServerColName
{
    def = 0,
    configType,
    remarks,
    address,
    port,
    security,
    network,
    subRemarks,
    testResult,

    todayDown,
    todayUp,
    totalDown,
    totalUp
}

public enum ETransport
{
    tcp,
    kcp,
    ws,
    httpupgrade,
    splithttp,
    h2,
    http,
    quic,
    grpc
}
