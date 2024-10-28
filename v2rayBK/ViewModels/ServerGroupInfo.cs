using System.Text.Json.Serialization;
using DynamicData;
using FluentAvalonia.Core;
using ServiceLib.Models;

namespace v2rayBK.ViewModels;

public partial class ServerGroupInfo : ViewModelBase
{
    [ObservableProperty]
    private string _name;

    [ObservableProperty]
    private string _address;

    [ObservableProperty]
    private int _serverSeletedIndex = -1;

    private int _serverSeletedIndexCache = -1;

    public int ServerSeletedIndexCache
    {
        get { return ServerSeletedIndex; }
        set { _serverSeletedIndexCache = value; }
    }

    [ObservableProperty]
    private ObservableCollection<ServerGroupItem> _servers = new();

    public List<ProfileItem> Profiles { get; set; } = new();

    [JsonIgnore]
    public ServerGroupItem SelectedServer => Servers.ElementAtOrDefault(ServerSeletedIndex);

    [JsonIgnore]
    public ProfileItem SelectedProfile => Profiles.ElementAtOrDefault(ServerSeletedIndex);

    public ServerGroupInfo() { }

    public void UpdateServers(List<ProfileItem> profiles)
    {
        Profiles.Clear();
        Profiles.AddRange(profiles);

        var newServers = profiles
            .Select(t => new ServerGroupItem
            {
                ConfigType = t.ConfigType.ToString(),
                Remarks = t.Remarks,
                Address = t.Address,
                Port = t.Port.ToString(),
                Security = t.Security,
                Network = t.Network,
            })
            .ToList();
        foreach (var oldserver in Servers)
        {
            var items = newServers.Where(t =>
                t.ConfigType == oldserver.ConfigType
                && t.Remarks == oldserver.Remarks
                && t.Address == oldserver.Address
                && t.Port == oldserver.Port
            );
            foreach (var item in items)
            {
                item.IsSeletedServer = oldserver.IsSeletedServer && oldserver == SelectedServer;
                item.TodayDown = oldserver.TodayDown;
                item.TodayUp = oldserver.TodayUp;
                item.TotalDown = oldserver.TotalDown;
                item.TotalUp = oldserver.TotalUp;
            }
        }

        ServerSeletedIndex = 0;
        Servers.Clear();
        Servers.AddRange(newServers);
        foreach (var server in Servers)
        {
            if (server.IsSeletedServer)
                break;
            ServerSeletedIndex++;
        }
        if (ServerSeletedIndex >= Servers.Count)
            ServerSeletedIndex = -1;
        OnPropertyChanged(nameof(ServerSeletedIndexCache));
    }

    public void RestoreSeletedServer()
    {
        for (int i = 0; i < Servers.Count; i++)
        {
            if (Servers[i].IsSeletedServer)
            {
                ServerSeletedIndex = i;
                break;
            }
        }
    }

    public void UpdateSelectedServer()
    {
        ServerSeletedIndex = _serverSeletedIndexCache;

        foreach (var server in Servers)
            server.IsSeletedServer = false;

        if (SelectedServer != null)
            SelectedServer.IsSeletedServer = true;
    }
}
