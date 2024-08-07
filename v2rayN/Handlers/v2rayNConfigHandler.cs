﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using v2rayN.Config;
using v2rayN.Extensions;
using v2rayN.Handlers.Fmt;

namespace v2rayN.Handlers;

/// <summary>
/// 本软件配置文件处理类
/// </summary>
class v2rayNConfigHandler
{
    private static string configRes = Global.ConfigFileName;

    /// <summary>
    /// 载入配置文件
    /// </summary>
    /// <param name="config"></param>
    /// <returns></returns>
    public static int LoadConfig(ref Config.V2RayNConfig config)
    {
        //载入配置文件
        string result = Misc.LoadResource(Misc.GetPath(configRes));
        if (!Misc.IsNullOrEmpty(result))
        {
            //转成Json
            config = Json.FromJson<Config.V2RayNConfig>(result);
        }
        if (config == null)
        {
            config = new Config.V2RayNConfig
            {
                index = -1,
                logEnabled = false,
                loglevel = "warning",
                vmess = new List<ProfileItem>(),

                //Mux
                muxEnabled = false,

                // 默认开启统计
                enableStatistics = true,

                // 默认一秒刷新率
                statisticsFreshRate = (int)Global.StatisticsFreshRate.quick
            };
        }

        //本地监听
        if (config.inbound == null)
        {
            config.inbound = new List<InItem>();
            InItem inItem = new InItem
            {
                protocol = Global.InboundSocks,
                localPort = 10808,
                udpEnabled = true,
                sniffingEnabled = true
            };

            config.inbound.Add(inItem);
        }
        else
        {
            //http协议不由core提供,只保留socks
            if (config.inbound.Count > 0)
            {
                config.inbound[0].protocol = Global.InboundSocks;
            }
        }
        //路由规则
        if (Misc.IsNullOrEmpty(config.domainStrategy))
        {
            config.domainStrategy = "IPIfNonMatch";
        }
        if (Misc.IsNullOrEmpty(config.routingMode))
        {
            config.routingMode = "0";
        }
        if (config.userproxy == null)
        {
            config.userproxy = new List<string>();
        }
        if (config.userdirect == null)
        {
            config.userdirect = new List<string>();
        }
        if (config.userblock == null)
        {
            config.userblock = new List<string>();
        }
        //kcp
        if (config.kcpItem == null)
        {
            config.kcpItem = new KcpItem
            {
                mtu = 1350,
                tti = 50,
                uplinkCapacity = 12,
                downlinkCapacity = 100,
                readBufferSize = 2,
                writeBufferSize = 2,
                congestion = false
            };
        }
        if (config.uiItem == null)
        {
            config.uiItem = new UIItem();
        }
        if (config.uiItem.mainLvColWidth == null)
        {
            config.uiItem.mainLvColWidth = new Dictionary<string, int>();
        }

        // 如果是用户升级，首次会有端口号为0的情况，不可用，这里处理
        if (Misc.IsNullOrEmpty(config.speedTestUrl))
        {
            config.speedTestUrl = Global.SpeedTestUrl;
        }
        if (Misc.IsNullOrEmpty(config.speedPingTestUrl))
        {
            config.speedPingTestUrl = Global.SpeedPingTestUrl;
        }

        if (config.subItem == null)
        {
            config.subItem = new List<SubItem>();
        }

        if (config == null || config.index < 0 || config.vmess.Count <= 0 || config.index > config.vmess.Count - 1)
        {
            Global.reloadV2ray = false;
        }
        else
        {
            Global.reloadV2ray = true;
        }

        return 0;
    }

    /// <summary>
    /// 添加服务器或编辑
    /// </summary>
    /// <param name="config"></param>
    /// <param name="vmessItem"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static int AddServer(ref Config.V2RayNConfig config, ProfileItem vmessItem, int index)
    {
        vmessItem.configVersion = Global.configVersion;
        vmessItem.configType = EConfigType.VMess;

        vmessItem.address = vmessItem.address.TrimEx();
        vmessItem.id = vmessItem.id.TrimEx();
        vmessItem.security = vmessItem.security.TrimEx();
        vmessItem.network = vmessItem.network.TrimEx();
        vmessItem.headerType = vmessItem.headerType.TrimEx();
        vmessItem.requestHost = vmessItem.requestHost.TrimEx();
        vmessItem.path = vmessItem.path.TrimEx();
        vmessItem.streamSecurity = vmessItem.streamSecurity.TrimEx();

        if (index >= 0)
        {
            //修改
            config.vmess[index] = vmessItem;
            if (config.index.Equals(index))
            {
                Global.reloadV2ray = true;
            }
        }
        else
        {
            //添加
            if (Misc.IsNullOrEmpty(vmessItem.allowInsecure))
            {
                vmessItem.allowInsecure = config.defAllowInsecure.ToString();
            }
            config.vmess.Add(vmessItem);
            if (config.vmess.Count == 1)
            {
                config.index = 0;
                Global.reloadV2ray = true;
            }
        }

        ToJsonFile(config);

        return 0;
    }

    /// <summary>
    /// 移除服务器
    /// </summary>
    /// <param name="config"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static int RemoveServer(ref Config.V2RayNConfig config, int index)
    {
        if (index < 0 || index > config.vmess.Count - 1)
        {
            return -1;
        }

        //删除
        config.vmess.RemoveAt(index);

        //移除的是活动的
        if (config.index.Equals(index))
        {
            if (config.vmess.Count > 0)
            {
                config.index = 0;
            }
            else
            {
                config.index = -1;
            }
            Global.reloadV2ray = true;
        }
        else if (index < config.index) //移除活动之前的
        {
            config.index--;
            Global.reloadV2ray = true;
        }

        ToJsonFile(config);

        return 0;
    }

    /// <summary>
    /// 克隆服务器
    /// </summary>
    /// <param name="config"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static int CopyServer(ref Config.V2RayNConfig config, int index)
    {
        if (index < 0 || index > config.vmess.Count - 1)
        {
            return -1;
        }

        ProfileItem vmessItem = new ProfileItem
        {
            configVersion = config.vmess[index].configVersion,
            address = config.vmess[index].address,
            port = config.vmess[index].port,
            id = config.vmess[index].id,
            alterId = config.vmess[index].alterId,
            security = config.vmess[index].security,
            network = config.vmess[index].network,
            remarks = string.Format("{0}-clone", config.vmess[index].remarks),
            headerType = config.vmess[index].headerType,
            requestHost = config.vmess[index].requestHost,
            path = config.vmess[index].path,
            streamSecurity = config.vmess[index].streamSecurity,
            allowInsecure = config.vmess[index].allowInsecure,
            configType = config.vmess[index].configType
        };

        config.vmess.Insert(index + 1, vmessItem); // 插入到下一项

        ToJsonFile(config);

        return 0;
    }

    /// <summary>
    /// 设置活动服务器
    /// </summary>
    /// <param name="config"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static int SetDefaultServer(ref Config.V2RayNConfig config, int index)
    {
        if (index < 0 || index > config.vmess.Count - 1)
        {
            return -1;
        }

        ////和现在相同
        //if (config.index.Equals(index))
        //{
        //    return -1;
        //}
        config.index = index;
        Global.reloadV2ray = true;

        ToJsonFile(config);

        return 0;
    }

    /// <summary>
    /// 保参数
    /// </summary>
    /// <param name="config"></param>
    /// <returns></returns>
    public static int SaveConfig(ref Config.V2RayNConfig config, bool reload = true)
    {
        Global.reloadV2ray = reload;

        ToJsonFile(config);

        return 0;
    }

    /// <summary>
    /// 存储文件
    /// </summary>
    /// <param name="config"></param>
    private static void ToJsonFile(Config.V2RayNConfig config)
    {
        Json.ToJsonFile(config, Misc.GetPath(configRes));
    }

    /// <summary>
    /// 取得服务器QRCode配置
    /// </summary>
    /// <param name="config"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static string GetVmessQRCode(Config.V2RayNConfig config, int index)
    {
        try
        {
            string url = string.Empty;

            ProfileItem vmessItem = config.vmess[index];
            if (vmessItem.configType == EConfigType.VMess)
            {
                VmessQRCode vmessQRCode = new VmessQRCode
                {
                    v = vmessItem.configVersion,
                    ps = vmessItem.remarks.TrimEx(), //备注也许很长 ;
                    add = vmessItem.address,
                    port = vmessItem.port,
                    id = vmessItem.id,
                    aid = vmessItem.alterId,
                    net = vmessItem.network,
                    type = vmessItem.headerType,
                    host = vmessItem.requestHost,
                    path = vmessItem.path,
                    tls = vmessItem.streamSecurity
                };

                url = Json.ToJson(vmessQRCode);
                url = Misc.Base64Encode(url);
                url = string.Format("{0}{1}", Global.vmessProtocol, url);
            }
            else if (vmessItem.configType == EConfigType.Shadowsocks)
            {
                string remark = string.Empty;
                if (!Misc.IsNullOrEmpty(vmessItem.remarks))
                {
                    remark = "#" + WebUtility.UrlEncode(vmessItem.remarks);
                }
                url = string.Format(
                    "{0}:{1}@{2}:{3}",
                    vmessItem.security,
                    vmessItem.id,
                    vmessItem.address,
                    vmessItem.port
                );
                url = Misc.Base64Encode(url);
                url = string.Format("{0}{1}{2}", Global.ssProtocol, url, remark);
            }
            else if (vmessItem.configType == EConfigType.Socks)
            {
                string remark = string.Empty;
                if (!Misc.IsNullOrEmpty(vmessItem.remarks))
                {
                    remark = "#" + WebUtility.UrlEncode(vmessItem.remarks);
                }
                url = string.Format(
                    "{0}:{1}@{2}:{3}",
                    vmessItem.security,
                    vmessItem.id,
                    vmessItem.address,
                    vmessItem.port
                );
                url = Misc.Base64Encode(url);
                url = string.Format("{0}{1}{2}", Global.socksProtocol, url, remark);
            }
            else if (vmessItem.configType == EConfigType.Trojan)
            {
                string remark = string.Empty;
                if (!Misc.IsNullOrEmpty(vmessItem.remarks))
                {
                    remark = "#" + WebUtility.UrlEncode(vmessItem.remarks);
                }
                string query = string.Empty;
                if (!Misc.IsNullOrEmpty(vmessItem.requestHost))
                {
                    query = string.Format("?sni={0}", vmessItem.requestHost);
                }
                url = string.Format("{0}@{1}:{2}", vmessItem.id, vmessItem.address, vmessItem.port);
                url = string.Format("{0}{1}{2}{3}", Global.trojanProtocol, url, query, remark);
            }
            else { }
            return url;
        }
        catch
        {
            return "";
        }
    }

    /// <summary>
    /// 移动服务器
    /// </summary>
    /// <param name="config"></param>
    /// <param name="index"></param>
    /// <param name="eMove"></param>
    /// <returns></returns>
    public static int MoveServer(ref Config.V2RayNConfig config, int index, EMove eMove)
    {
        int count = config.vmess.Count;
        if (index < 0 || index > config.vmess.Count - 1)
        {
            return -1;
        }
        switch (eMove)
        {
            case EMove.Top:
                {
                    if (index == 0)
                    {
                        return 0;
                    }
                    ProfileItem vmess = Misc.DeepCopy(config.vmess[index]);
                    config.vmess.RemoveAt(index);
                    config.vmess.Insert(0, vmess);
                    if (index < config.index)
                    {
                        //
                    }
                    else if (config.index == index)
                    {
                        config.index = 0;
                    }
                    else
                    {
                        config.index++;
                    }
                    break;
                }
            case EMove.Up:
                {
                    if (index == 0)
                    {
                        return 0;
                    }
                    ProfileItem vmess = Misc.DeepCopy(config.vmess[index]);
                    config.vmess.RemoveAt(index);
                    config.vmess.Insert(index - 1, vmess);
                    if (index == config.index + 1)
                    {
                        config.index++;
                    }
                    else if (config.index == index)
                    {
                        config.index--;
                    }
                    break;
                }

            case EMove.Down:
                {
                    if (index == count - 1)
                    {
                        return 0;
                    }
                    ProfileItem vmess = Misc.DeepCopy(config.vmess[index]);
                    config.vmess.RemoveAt(index);
                    config.vmess.Insert(index + 1, vmess);
                    if (index == config.index - 1)
                    {
                        config.index--;
                    }
                    else if (config.index == index)
                    {
                        config.index++;
                    }
                    break;
                }
            case EMove.Bottom:
                {
                    if (index == count - 1)
                    {
                        return 0;
                    }
                    ProfileItem vmess = Misc.DeepCopy(config.vmess[index]);
                    config.vmess.RemoveAt(index);
                    config.vmess.Add(vmess);
                    if (index < config.index)
                    {
                        config.index--;
                    }
                    else if (config.index == index)
                    {
                        config.index = count - 1;
                    }
                    else
                    {
                        //
                    }
                    break;
                }
        }
        Global.reloadV2ray = true;

        ToJsonFile(config);

        return 0;
    }

    /// <summary>
    /// 添加自定义服务器
    /// </summary>
    /// <param name="config"></param>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static int AddCustomServer(ref Config.V2RayNConfig config, string fileName)
    {
        string newFileName = string.Format("{0}.json", Misc.GetGUID());
        //newFileName = Path.Combine(Misc.GetTempPath(), newFileName);

        try
        {
            File.Copy(fileName, Path.Combine(Misc.GetTempPath(), newFileName));
        }
        catch
        {
            return -1;
        }

        ProfileItem vmessItem = new ProfileItem
        {
            address = newFileName,
            configType = EConfigType.Custom,
            remarks = string.Format("import custom@{0}", DateTime.Now.ToShortDateString())
        };

        config.vmess.Add(vmessItem);
        if (config.vmess.Count == 1)
        {
            config.index = 0;
            Global.reloadV2ray = true;
        }

        ToJsonFile(config);

        return 0;
    }

    /// <summary>
    /// 添加服务器或编辑
    /// </summary>
    /// <param name="config"></param>
    /// <param name="vmessItem"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static int EditCustomServer(ref Config.V2RayNConfig config, ProfileItem vmessItem, int index)
    {
        //修改
        config.vmess[index] = vmessItem;
        if (config.index.Equals(index))
        {
            Global.reloadV2ray = true;
        }

        ToJsonFile(config);

        return 0;
    }

    /// <summary>
    /// 添加服务器或编辑
    /// </summary>
    /// <param name="config"></param>
    /// <param name="vmessItem"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static int AddShadowsocksServer(ref Config.V2RayNConfig config, ProfileItem vmessItem, int index)
    {
        vmessItem.configVersion = Global.configVersion;
        vmessItem.configType = EConfigType.Shadowsocks;

        vmessItem.address = vmessItem.address.TrimEx();
        vmessItem.id = vmessItem.id.TrimEx();
        vmessItem.security = vmessItem.security.TrimEx();

        if (index >= 0)
        {
            //修改
            config.vmess[index] = vmessItem;
            if (config.index.Equals(index))
            {
                Global.reloadV2ray = true;
            }
        }
        else
        {
            //添加
            config.vmess.Add(vmessItem);
            if (config.vmess.Count == 1)
            {
                config.index = 0;
                Global.reloadV2ray = true;
            }
        }

        ToJsonFile(config);

        return 0;
    }

    /// <summary>
    /// 添加服务器或编辑
    /// </summary>
    /// <param name="config"></param>
    /// <param name="vmessItem"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static int AddSocksServer(ref Config.V2RayNConfig config, ProfileItem vmessItem, int index)
    {
        vmessItem.configVersion = Global.configVersion;
        vmessItem.configType = EConfigType.Socks;

        vmessItem.address = vmessItem.address.TrimEx();

        if (index >= 0)
        {
            //修改
            config.vmess[index] = vmessItem;
            if (config.index.Equals(index))
            {
                Global.reloadV2ray = true;
            }
        }
        else
        {
            //添加
            config.vmess.Add(vmessItem);
            if (config.vmess.Count == 1)
            {
                config.index = 0;
                Global.reloadV2ray = true;
            }
        }

        ToJsonFile(config);

        return 0;
    }

    /// <summary>
    /// 添加服务器或编辑
    /// </summary>
    /// <param name="config"></param>
    /// <param name="vmessItem"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static int AddTrojanServer(ref Config.V2RayNConfig config, ProfileItem vmessItem, int index)
    {
        vmessItem.configVersion = Global.configVersion;
        vmessItem.configType = EConfigType.Trojan;

        vmessItem.address = vmessItem.address.TrimEx();
        vmessItem.id = vmessItem.id.TrimEx();

        vmessItem.streamSecurity = Global.StreamSecurity;
        vmessItem.allowInsecure = "false";

        if (index >= 0)
        {
            //修改
            config.vmess[index] = vmessItem;
            if (config.index.Equals(index))
            {
                Global.reloadV2ray = true;
            }
        }
        else
        {
            //添加
            config.vmess.Add(vmessItem);
            if (config.vmess.Count == 1)
            {
                config.index = 0;
                Global.reloadV2ray = true;
            }
        }

        ToJsonFile(config);

        return 0;
    }

    /// <summary>
    /// 批量添加服务器
    /// </summary>
    /// <param name="config"></param>
    /// <param name="clipboardData"></param>
    /// <param name="subid"></param>
    /// <returns>成功导入的数量</returns>
    public static int AddBatchServers(
        ref Config.V2RayNConfig config,
        string clipboardData,
        string subid = "",
        string protocolFilter = ""
    )
    {
        if (Misc.IsNullOrEmpty(clipboardData))
        {
            return -1;
        }

        int countServers = 0;

        string[] arrData = clipboardData.Split(Environment.NewLine.ToCharArray()).Distinct().ToArray();
        string[] arrProtocolFilter = protocolFilter.Split(",");
        foreach (string str in arrData)
        {
            //maybe sub
            if (str.StartsWith(Global.httpsProtocol) || str.StartsWith(Global.httpProtocol))
            {
                if (AddSubItem(ref config, str) == 0)
                {
                    countServers++;
                }
                continue;
            }
            ProfileItem profileItem = FmtHandler.ResolveConfig(str, out string msg);
            if (profileItem == null)
            {
                continue;
            }
            profileItem.subid = subid;
            var addStatus = profileItem.configType switch
            {
                EConfigType.VMess => AddServer(ref config, profileItem, -1),
                EConfigType.Shadowsocks => AddShadowsocksServer(ref config, profileItem, -1),
                EConfigType.Socks => AddSocksServer(ref config, profileItem, -1),
                EConfigType.Trojan => AddTrojanServer(ref config, profileItem, -1),
                EConfigType.VLESS => AddVlessServer(ref config, profileItem, -1),
                _ => -1,
            };
            if (addStatus == 0)
            {
                countServers++;
            }
        }
        return countServers;
    }

    /// <summary>
    /// add sub
    /// </summary>
    /// <param name="config"></param>
    /// <param name="url"></param>
    /// <returns></returns>
    public static int AddSubItem(ref Config.V2RayNConfig config, string url)
    {
        //already exists
        foreach (SubItem sub in config.subItem)
        {
            if (url == sub.url)
            {
                return 0;
            }
        }

        SubItem subItem = new SubItem
        {
            id = string.Empty,
            remarks = "import sub",
            url = url
        };
        config.subItem.Add(subItem);

        return SaveSubItem(ref config);
    }

    /// <summary>
    /// save sub
    /// </summary>
    /// <param name="config"></param>
    /// <returns></returns>
    public static int SaveSubItem(ref Config.V2RayNConfig config)
    {
        if (config.subItem == null || config.subItem.Count <= 0)
        {
            return -1;
        }

        foreach (SubItem sub in config.subItem)
        {
            if (Misc.IsNullOrEmpty(sub.id))
            {
                sub.id = Misc.GetGUID();
            }
        }

        ToJsonFile(config);
        return 0;
    }

    /// <summary>
    /// 移除服务器
    /// </summary>
    /// <param name="config"></param>
    /// <param name="subid"></param>
    /// <returns></returns>
    public static int RemoveServerViaSubid(ref Config.V2RayNConfig config, string subid)
    {
        if (Misc.IsNullOrEmpty(subid) || config.vmess.Count <= 0)
        {
            return -1;
        }
        for (int k = config.vmess.Count - 1; k >= 0; k--)
        {
            if (config.vmess[k].subid.Equals(subid))
            {
                config.vmess.RemoveAt(k);
            }
        }

        ToJsonFile(config);
        return 0;
    }

    public static int AddformMainLvColWidth(ref Config.V2RayNConfig config, string name, int width)
    {
        if (config.uiItem.mainLvColWidth == null)
        {
            config.uiItem.mainLvColWidth = new Dictionary<string, int>();
        }
        if (config.uiItem.mainLvColWidth.ContainsKey(name))
        {
            config.uiItem.mainLvColWidth[name] = width;
        }
        else
        {
            config.uiItem.mainLvColWidth.Add(name, width);
        }
        return 0;
    }

    public static int GetformMainLvColWidth(ref Config.V2RayNConfig config, string name, int width)
    {
        if (config.uiItem.mainLvColWidth == null)
        {
            config.uiItem.mainLvColWidth = new Dictionary<string, int>();
        }
        if (config.uiItem.mainLvColWidth.ContainsKey(name))
        {
            return config.uiItem.mainLvColWidth[name];
        }
        else
        {
            return width;
        }
    }

    public static int SortServers(ref Config.V2RayNConfig config, EServerColName name, bool asc)
    {
        if (config.vmess.Count <= 0)
        {
            return -1;
        }
        switch (name)
        {
            case EServerColName.configType:
            case EServerColName.remarks:
            case EServerColName.address:
            case EServerColName.port:
            case EServerColName.security:
            case EServerColName.network:
            case EServerColName.testResult:
                break;
            default:
                return -1;
        }
        string itemId = config.getItemId();
        var items = config.vmess.AsQueryable();

        if (asc)
        {
            config.vmess = items.OrderBy(name.ToString()).ToList();
        }
        else
        {
            config.vmess = items.OrderByDescending(name.ToString()).ToList();
        }

        var index_ = config.vmess.FindIndex(it => it.getItemId() == itemId);
        if (index_ >= 0)
        {
            config.index = index_;
        }

        ToJsonFile(config);
        return 0;
    }

    /// <summary>
    /// 添加服务器或编辑
    /// </summary>
    /// <param name="config"></param>
    /// <param name="vmessItem"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static int AddVlessServer(ref Config.V2RayNConfig config, ProfileItem vmessItem, int index)
    {
        vmessItem.configVersion = Global.configVersion;
        vmessItem.configType = EConfigType.VLESS;

        vmessItem.address = vmessItem.address.TrimEx();
        vmessItem.id = vmessItem.id.TrimEx();
        vmessItem.security = vmessItem.security.TrimEx();
        vmessItem.network = vmessItem.network.TrimEx();
        vmessItem.headerType = vmessItem.headerType.TrimEx();
        vmessItem.requestHost = vmessItem.requestHost.TrimEx();
        vmessItem.path = vmessItem.path.TrimEx();
        vmessItem.streamSecurity = vmessItem.streamSecurity.TrimEx();

        if (index >= 0)
        {
            //修改
            config.vmess[index] = vmessItem;
            if (config.index.Equals(index))
            {
                Global.reloadV2ray = true;
            }
        }
        else
        {
            //添加
            if (Misc.IsNullOrEmpty(vmessItem.allowInsecure))
            {
                vmessItem.allowInsecure = config.defAllowInsecure.ToString();
            }
            config.vmess.Add(vmessItem);
            if (config.vmess.Count == 1)
            {
                config.index = 0;
                Global.reloadV2ray = true;
            }
        }

        ToJsonFile(config);

        return 0;
    }
}
