namespace v2rayBK.ViewModels.Pages;

public partial class SubscribeSettingsPageViewModel : ViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<ServerGroupInfo> _serverGroup;

    public SubscribeSettingsPageViewModel()
    {
        _serverGroup = new()
        {
            new ServerGroupInfo()
            {
                Name = "test1",
                Address = "sfe",
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
    }

    [RelayCommand]
    public void NewSubscribe()
    {
        ServerGroup.Add(new ServerGroupInfo());
    }

    public void DeleteSubscribe(ServerGroupInfo serverGroupInfo)
    {
        ServerGroup.Remove(serverGroupInfo);
    }
}
