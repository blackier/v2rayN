using Downloader;
using Octokit;
using Octokit.Internal;
using ServiceLib.Handler;
using ServiceLib.Helper;
using ServiceLib.Manager;
using ServiceLib.Models;
using ServiceLib.Services;
using System;
using System.Net;
using System.Threading;

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
        AppManager.Instance.InitApp();

        Config config = AppManager.Instance.Config;
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
        await SQLiteHelper.Instance.DeleteAsync(fakeSubItem);
        await SQLiteHelper.Instance.ReplaceAsync(fakeSubItem);

        await SubscriptionHandler.UpdateProcess(
            config,
            fakeSubItem.Id,
            v2RayBKConfig.PullSubscribeWithProxy,
            async (bool success, string msg) =>
            {
                App.PostLog(msg);
                if (success)
                {
                    var items = await AppManager.Instance.ProfileItems(fakeSubItem.Id);
                    if (items == null || !items.Any())
                        return;
                    server.UpdateServers(items);
                    if (v2RayBKConfig.SpeedTestAfterPullSubscribe)
                        v2RayBKConfig.SeepTestServer();
                }
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

    public void UpdateXRay(string lastVerisonUrl)
    {
        _ = DownloadFile(
            lastVerisonUrl,
            (fileName) =>
            {
                v2RayBKConfig.StopV2RayCore();
                FileManager.ZipExtractToFile(fileName, Utils.StartupPath(), "");
                App.PostTask(() => RestartServer());
            }
        );
    }

    [RelayCommand]
    public void UpdateGeoSite()
    {
        UpdateGeoFile(GlobalEx.GeoSiteLatestUrl);
    }

    [RelayCommand]
    public void UpdateGeoIP()
    {
        UpdateGeoFile(GlobalEx.GeoIPLatestUrl);
    }

    public void UpdateGeoFile(string fileUrl)
    {
        _ = DownloadFile(
            fileUrl,
            (fileName) =>
            {
                v2RayBKConfig.StopV2RayCore();
                File.Copy(fileName, Path.Combine(Utils.StartupPath(), Path.GetFileName(fileName)), true);
                App.PostTask(() => RestartServer());
            }
        );
    }

    public async Task DownloadFile(string fileUrl, Action<string> DownloadCompleted)
    {
        string fileName = Utils.GetTempPath(Path.GetFileName(fileUrl));
        File.Delete(fileName);

        IDownload download = DownloadBuilder
            .New()
            .WithUrl(fileUrl)
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
                App.PostLog($"DownloadProgress: {preProgress}%");
            }
        };
        download.DownloadFileCompleted += (object sender, System.ComponentModel.AsyncCompletedEventArgs e) =>
        {
            if (e.Error != null)
            {
                App.PostLog($"DownloadFile fail, {e.Error}");
                return;
            }
            DownloadCompleted?.Invoke(fileName);
        };
        await download.StartAsync();
    }
}
