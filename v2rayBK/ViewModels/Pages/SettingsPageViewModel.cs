using v2rayBK.Common;

namespace v2rayBK.ViewModels.Pages;

public partial class SettingsPageViewModel : ViewModelBase
{
    [ObservableProperty]
    private bool _isAutoStart = Misc.IsAutoRun();

    partial void OnIsAutoStartChanged(bool value)
    {
        Misc.SetAutoRun(value);
    }

    [ObservableProperty]
    private List<string> _logLevel = new() { "debug", "info", "warning", "error", "none" };

    [ObservableProperty]
    private List<string> _domainStrategy = new() { "AsIs", "IPIfNonMatch", "IPOnDemand" };

    public string ProxyDomain
    {
        get { return string.Join(",\n", v2RayBKConfig.UserProxy); }
        set { v2RayBKConfig.UserProxy = value.Split(',').Select(t => t.TrimEx()).ToList(); }
    }

    public string DirectDomain
    {
        get { return string.Join(",\n", v2RayBKConfig.UserDirect); }
        set { v2RayBKConfig.UserDirect = value.Split(',').Select(t => t.TrimEx()).ToList(); }
    }

    public string BlockDomain
    {
        get { return string.Join(",\n", v2RayBKConfig.UserBlock); }
        set { v2RayBKConfig.UserBlock = value.Split(',').Select(t => t.TrimEx()).ToList(); }
    }

    public v2rayBKConfig v2RayBKConfig { get; }

    public SettingsPageViewModel(v2rayBKConfig v2RayBKConfig)
    {
        this.v2RayBKConfig = v2RayBKConfig;
    }
}
