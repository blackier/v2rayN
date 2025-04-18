using System;
using System.Net;
using System.Threading;
using Avalonia.Threading;
using Downloader;
using Octokit;
using Octokit.Internal;
using ServiceLib.Common;
using ServiceLib.Handler;
using ServiceLib.Models;
using ServiceLib.Services;

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
        AppHandler.Instance.InitApp();

        Config config = AppHandler.Instance.Config;
        config.CoreBasicItem = new();
        config.GuiItem = new();
        config.UiItem = new();
        config.Inbound = new();

        return config;
    }

    [RelayCommand]
    public async Task PullCurrentSubscribe()
    {
        var server = v2RayBKConfig.SelectedServerGroup;
        if (server == null)
            return;

        Config config = InitServeLib();

        SubItem fakeSubItem = new() { Id = "fakeid", Url = server.Address };
        await SQLiteHelper.Instance.ReplaceAsync(fakeSubItem);

        UpdateService updateService = new();
        _ = updateService.UpdateSubscriptionProcess(
            config,
            fakeSubItem.Id,
            v2RayBKConfig.PullSubscribeWithProxy,
            (bool success, string msg) =>
            {
                App.PostLog(msg);
                if (success)
                    App.PostTask(async () =>
                    {
                        var items = await AppHandler.Instance.ProfileItems(fakeSubItem.Id);
                        server.UpdateServers(items);
                        if (v2RayBKConfig.SpeedTestAfterPullSubscribe)
                            v2RayBKConfig.SeepTestServer();
                    });
            }
        );
    }

    public async Task<string> CheckUpdateXRayVersion()
    {
        try
        {
            // https://octokitnet.readthedocs.io/en/documentation/http-client/#proxy-support
            var client = new GitHubClient(
                new Connection(
                    new ProductHeaderValue("XRay-core"),
                    new HttpClientAdapter(
                        () =>
                            HttpMessageHandlerFactory.CreateDefault(
                                new WebProxy(Global.Loopback, v2RayBKConfig.HttpInboundPort)
                            )
                    )
                )
            );
            var release = await client.Repository.Release.GetAll("XTLS", "Xray-core");
            return release.First().Assets.Where(t => t.Name.EndsWith("windows-64.zip")).First().BrowserDownloadUrl;
        }
        catch (Exception ex)
        {
            App.PostLog(ex.Message);
        }
        return "";
    }

    public async void UpdateXRay(string lastVerisonUrl)
    {
        string fileName = Utils.GetTempPath(Path.GetFileName(lastVerisonUrl));
        File.Delete(fileName);

        IDownload download = DownloadBuilder
            .New()
            .WithUrl(lastVerisonUrl)
            .WithDirectory("")
            .WithFileName(fileName)
            .WithConfiguration(
                new()
                {
                    RequestConfiguration = { Proxy = new WebProxy(Global.Loopback, v2RayBKConfig.HttpInboundPort) }
                }
            )
            .Build();

        int preProgress = -1;
        download.DownloadProgressChanged += (object sender, Downloader.DownloadProgressChangedEventArgs e) =>
        {
            int progress = (int)(e.ProgressPercentage);
            if (progress - preProgress >= 1)
            {
                preProgress = progress;
                App.PostLog($"UpdateXRay DownloadProgress: {preProgress}%");
            }
        };
        download.DownloadFileCompleted += (object sender, System.ComponentModel.AsyncCompletedEventArgs e) =>
        {
            if (e.Error != null)
            {
                App.PostLog($"UpdateXRay fail, {e.Error}");
                return;
            }
            v2RayBKConfig.StopV2RayCore();
            FileManager.ZipExtractToFile(fileName, Utils.StartupPath(), "");
            App.PostTask(() => RestartServer());
        };
        await download.StartAsync();
    }
}
