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

    public v2rayBKConfig v2RayBKConfig { get; }

    public SettingsPageViewModel(v2rayBKConfig v2RayBKConfig)
    {
        this.v2RayBKConfig = v2RayBKConfig;
    }
}
