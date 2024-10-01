using v2rayBK.Common;

namespace v2rayBK.ViewModels.Pages;

public partial class RoutingPageViewModel : ViewModelBase
{
    [ObservableProperty]
    private List<string> _domainStrategy = new() { "AsIs", "IPIfNonMatch", "IPOnDemand" };

    public v2rayBKConfig v2RayBKConfig { get; }

    public RoutingPageViewModel(v2rayBKConfig v2RayBKConfig)
    {
        this.v2RayBKConfig = v2RayBKConfig;
    }
}
