using System;
using System.Threading;
using Avalonia.Threading;
using ServiceLib.Common;
using ServiceLib.Handler;
using ServiceLib.Models;
using v2rayBK.Handlers;

namespace v2rayBK.ViewModels.Pages;

public partial class HomePageViewModel : ViewModelBase
{
    public v2rayBKConfig v2RayBKConfig { get; }

    public HomePageViewModel(v2rayBKConfig v2RayBKConfig)
    {
        this.v2RayBKConfig = v2RayBKConfig;
    }

    [RelayCommand]
    public void RestartServer()
    {
        v2RayBKConfig.StartServer();
    }

    public void StartSeletedServer()
    {
        v2RayBKConfig.StartSelectedServer();
    }

    public Config InitServeLib()
    {
        Config config =
            new()
            {
                coreBasicItem = new(),
                guiItem = new(),
                uiItem = new(),
                inbound = new()
            };
        LazyConfig.Instance.SetConfig(config);
        return config;
    }

    [RelayCommand]
    public void PullCurrentSubscribe()
    {
        var server = v2RayBKConfig.SelectedServerGroup;
        if (server == null)
            return;

        Config config = InitServeLib();

        SubItem fakeSubItem = new() { id = "fakeid", url = server.Address };
        SQLiteHelper.Instance.Replace(fakeSubItem);

        UpdateHandler updateHandle = new();
        updateHandle.UpdateSubscriptionProcess(
            config,
            fakeSubItem.id,
            v2RayBKConfig.PullSubscribeWithProxy,
            (bool success, string msg) =>
            {
                App.PostLog(msg);
                if (success)
                    App.PostTask(() =>
                    {
                        var items = LazyConfig.Instance.ProfileItems(fakeSubItem.id);
                        server.UpdateServers(items);
                        if (v2RayBKConfig.SpeedTestAfterPullSubscribe)
                            v2RayBKConfig.SeepTestServer();
                    });
            }
        );
    }

    public async Task<string> CheckUpdateXRayVersion()
    {
        Config config = InitServeLib();

        UpdateHandler updateHandle = new();
        return await updateHandle.CheckUpdateCoreVersion(
            ServiceLib.Enums.ECoreType.Xray,
            config,
            (bool success, string msg) => { },
            false
        );
    }

    public void UpdateXRay(string lastVerisonUrl)
    {
        string fileName = Utils.GetTempPath(Path.GetFileName(lastVerisonUrl));

        DownloadHandler downloadHandler = new();
        downloadHandler.UpdateCompleted += (sender, args) =>
        {
            App.PostLog(args.Msg);
            if (args.Success)
            {
                FileManager.ZipExtractToFile(fileName, Utils.StartupPath(), "");
                App.PostTask(() => RestartServer());
            }
        };
        downloadHandler.Error += (sender, args) => { };

        _ = downloadHandler.DownloadFileAsync(lastVerisonUrl, fileName, true, 30);
    }
}
