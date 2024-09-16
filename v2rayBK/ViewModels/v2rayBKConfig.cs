using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ServiceLib.Models;
using v2rayBK.Common;
using v2rayBK.Handlers;

namespace v2rayBK.ViewModels;

public partial class v2rayBKConfig : ViewModelBase
{
    [ObservableProperty]
    private SystemProxyType _systemProxyType;

    // 入站

    [ObservableProperty]
    private int _httpInboundPort = 10809;

    [ObservableProperty]
    private int _socksInboundPort = 10808;

    [ObservableProperty]
    private bool _sniffingEnabled;

    // 日志

    [ObservableProperty]
    private bool _logEnabled;

    [ObservableProperty]
    private string _logLevel = "warning";

    // 出站

    [ObservableProperty]
    private bool _muxEnabled;

    [ObservableProperty]
    private bool _defAllowInsecure;

    // DNS

    [ObservableProperty]
    private bool _fakednsEnabled;

    [ObservableProperty]
    private bool _localDNSEnabled;

    /// <summary>
    /// 域名解析策略
    /// </summary>
    [ObservableProperty]
    private string _domainStrategy = "AsIs";

    /// <summary>
    /// 用户自定义需代理的网址或ip
    /// </summary>
    [ObservableProperty]
    private List<string> _userProxy;

    /// <summary>
    /// 用户自定义直连的网址或ip
    /// </summary>
    [ObservableProperty]
    private List<string> _userDirect;

    /// <summary>
    /// 用户自定义阻止的网址或ip
    /// </summary>
    [ObservableProperty]
    private List<string> _userBlock;

    /// <summary>
    /// 允许来自局域网的连接
    /// </summary>
    [ObservableProperty]
    private bool _allowLANConn;

    /// <summary>
    /// 启用实时网速和流量统计
    /// </summary>
    [ObservableProperty]
    private bool _enableStatistics = true;

    [property: JsonIgnore]
    [ObservableProperty]
    private long _directSpeedUp;

    [property: JsonIgnore]
    [ObservableProperty]
    private long _directSpeedDown;

    [property: JsonIgnore]
    [ObservableProperty]
    private long _proxySpeedUp;

    [property: JsonIgnore]
    [ObservableProperty]
    private long _proxySpeedDown;

    /// <summary>
    /// 服务器下载测速url
    /// </summary>
    [ObservableProperty]
    private string _speedTestUrl = "http://www.gstatic.com/generate_204";

    /// <summary>
    /// 服务器真连接延迟测试url
    /// </summary>
    [ObservableProperty]
    private string _speedPingTestUrl = "http://www.gstatic.com/generate_204";

    // 配置
    [ObservableProperty]
    private bool _pullSubscribeWithProxy = false;

    [ObservableProperty]
    private bool _speedTestAfterPullSubscribe = false;

    [ObservableProperty]
    private int _serverGroupSeletedIndex = -1;

    [ObservableProperty]
    private ObservableCollection<ServerGroupInfo> _serverGroup = new();

    [JsonIgnore]
    public ServerGroupInfo? SelectedServerGroup => ServerGroup.ElementAtOrDefault(ServerGroupSeletedIndex);

    private XRayExeHandler _xrayExeHandler;
    private StatisticsHandler _statisticsHandler;

    public v2rayBKConfig()
    {
        _serverGroup = new()
        {
            new ServerGroupInfo()
            {
                Name = "test1",
                Address = "sfe1",
                Servers = new()
                {
                    new() { ConfigType = "type1", Remarks = "remaks1" },
                    new() { ConfigType = "type2", Remarks = "remaks2" }
                }
            },
            new ServerGroupInfo()
            {
                Name = "test2",
                Address = "sfe2",
                Servers = new()
                {
                    new() { ConfigType = "type1", Remarks = "remaks1" }
                }
            }
        };

        _xrayExeHandler = new();
        _statisticsHandler = new(this);
    }

    public static v2rayBKConfig? LoadConfig()
    {
        //载入配置文件
        string? result = Utils.LoadResource(Utils.GetPath(GlobalEx.ConfigFileName));
        if (result.IsNullOrEmpty())
            return null;
        var config = Json.FromJson<v2rayBKConfig>(result);
        if (config != null)
        {
            foreach (var server in config.ServerGroup)
                server.RestoreSeletedServer();
        }
        return config;
    }

    public void SaveConfig()
    {
        Json.ToJsonFile(this, Utils.GetPath(GlobalEx.ConfigFileName));
    }

    public void Close()
    {
        _statisticsHandler?.Close();
        _xrayExeHandler?.V2rayStop();
        SaveConfig();
    }

    public ProfileItem? GetSelectedProfile()
    {
        return SelectedServerGroup?.SelectedProfile;
    }

    public ProfileItem? GetSelectedProfile(int index)
    {
        return SelectedServerGroup?.Profiles?.ElementAtOrDefault(index);
    }

    public ServerGroupItem? GetSelectedServer(int index)
    {
        return SelectedServerGroup?.Servers?.ElementAtOrDefault(index);
    }

    public void StartServer()
    {
        App.PostLog($"Start server: {SelectedServerGroup?.SelectedServer?.Remarks}");
        _xrayExeHandler.LoadV2ray(this);
        _statisticsHandler.Start();
        SystemProxyHandler.Update(this);
    }

    public void StartSelectedServer()
    {
        SelectedServerGroup?.UpdateSelectedServer();
        StartServer();
    }

    [property: JsonIgnore]
    [RelayCommand]
    public void SeepTestServer()
    {
        SeepTestServer(Enumerable.Range(0, SelectedServerGroup!.Servers.Count()).ToList());
    }

    public void SeepTestServer(List<int> seleteds)
    {
        foreach (var index in seleteds)
            GetSelectedServer(index)!.TestResult = "";
        Task.Run(() => SpeedTestHandler.RunRealPing(this, seleteds));
    }
}
