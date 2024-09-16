using System.Text.Json.Serialization;

namespace v2rayBK.ViewModels;

public partial class ServerGroupItem : ViewModelBase
{
    [ObservableProperty]
    private bool _isSeletedServer;

    [ObservableProperty]
    private string _configType;

    [ObservableProperty]
    private string _remarks;

    [ObservableProperty]
    private string _address;

    [ObservableProperty]
    private string _port;

    [ObservableProperty]
    private string _security;

    [ObservableProperty]
    private string _network;

    [ObservableProperty]
    private string _testResult;

    [property: JsonIgnore]
    [ObservableProperty]
    private long _todayDown;

    [property: JsonIgnore]
    [ObservableProperty]
    private long _todayUp;

    [ObservableProperty]
    private long _totalDown;

    [ObservableProperty]
    private long _totalUp;

    [JsonIgnore]
    public int SpeedTestPort = 0;
}
