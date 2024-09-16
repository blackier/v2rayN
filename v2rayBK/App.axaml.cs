using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Styling;
using Avalonia.Threading;
using v2rayBK.Handlers;
using v2rayBK.Services;
using v2rayBK.ViewModels;
using v2rayBK.ViewModels.Pages;
using v2rayBK.Views;
using v2rayBK.Views.Pages;

namespace v2rayBK;

public partial class App : Application
{
    private static readonly IHost _host = Host.CreateDefaultBuilder()
        .ConfigureAppConfiguration(c =>
        {
            c.SetBasePath(AppContext.BaseDirectory);
        })
        .ConfigureServices(
            (context, services) =>
            {
                // App Host
                services.AddHostedService<ApplicationHostService>();
                // Main window container with navigation
                services.AddSingleton<MainWindow>();
                // Page
                services.AddSingleton<HomePage>();
                services.AddTransient<SettingsPage>();
                // ViewModels
                services.AddSingleton<v2rayBKConfig>(v2rayBKConfig.LoadConfig() ?? new());
                services.AddSingleton<MainWindowViewModel>();
                services.AddSingleton<HomePageViewModel>();
                services.AddTransient<SettingsPageViewModel>();
                // Models
            }
        )
        .Build();

    private static int _uiThreadId;

    public override void Initialize()
    {
        _uiThreadId = Environment.CurrentManagedThreadId;
        DataContext = this;
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            if (ExistLaunchedApp())
            {
                desktop.Shutdown();
                return;
            }
            DesktopApp = desktop;
            DesktopApp.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            DesktopApp.Startup += DesktopApp_Startup;
            DesktopApp.Exit += Desktop_Exit;
        }

        base.OnFrameworkInitializationCompleted();
    }

    private async void DesktopApp_Startup(object? sender, ControlledApplicationLifetimeStartupEventArgs e)
    {
        await _host.StartAsync();

        // Line below is needed to remove Avalonia data validation.
        // Without this line you will get duplicate validations from both Avalonia and CT
        BindingPlugins.DataValidators.RemoveAt(0);
        DesktopApp.MainWindow = MainWindow;

        // ×ÔÆô¶¯
        GetRequiredService<HomePage>();
        v2rayBKConfig.StartServer();
        LoadTrayIcon();
    }

    private async void Desktop_Exit(object? sender, ControlledApplicationLifetimeExitEventArgs e)
    {
        GetRequiredService<v2rayBKConfig>().Close();
        await _host.StopAsync();
        _host.Dispose();
    }

    public static App? Get()
    {
        return App.Current as App;
    }

    public static T GetRequiredService<T>()
        where T : class
    {
        return _host.Services.GetRequiredService(typeof(T)) as T;
    }

    public v2rayBKConfig v2rayBKConfig => GetRequiredService<v2rayBKConfig>();

    public static IClassicDesktopStyleApplicationLifetime DesktopApp { get; set; }

    public static MainWindow MainWindow => GetRequiredService<MainWindow>();

    public static void ShowLoading() => MainWindow.ShowLoading();

    public static void HideLoading() => MainWindow.HideLoading();

    public static void PostLog(string log)
    {
        if (_uiThreadId == Environment.CurrentManagedThreadId)
            WeakReferenceMessenger.Default.Send(new MessageType.LogMessage(log));
        else
            Dispatcher.UIThread.Post(() => WeakReferenceMessenger.Default.Send(new MessageType.LogMessage(log)));
    }

    public static void PostTask(Action task)
    {
        if (_uiThreadId == Environment.CurrentManagedThreadId)
            task.Invoke();
        else
            Dispatcher.UIThread.Post(task);
    }

    public void LoadTrayIcon()
    {
        var trayIcon = TrayIcon.GetIcons(App.Current!)?.FirstOrDefault();
        switch (v2rayBKConfig.SystemProxyType)
        {
            case SystemProxyType.Http:
                trayIcon!.Icon = new(new Bitmap(AssetLoader.Open(new Uri("avares://v2rayBK/Assets/NotifyIcon2.ico"))));
                break;
            case SystemProxyType.Socks:
                trayIcon!.Icon = new(new Bitmap(AssetLoader.Open(new Uri("avares://v2rayBK/Assets/NotifyIcon3.ico"))));
                break;
            default:
                trayIcon!.Icon = new(new Bitmap(AssetLoader.Open(new Uri("avares://v2rayBK/Assets/NotifyIcon1.ico"))));
                break;
        }
    }

    private void tray_icon_TrayIcon_Clicked(object? sender, System.EventArgs e)
    {
        MainWindow.ShowWindow();
    }

    public void tray_system_proxy_NativeMenuItem_Click(object? sender, System.EventArgs e)
    {
        LoadTrayIcon();
        SystemProxyHandler.Update(v2rayBKConfig);
    }

    private void tray_exit_NativeMenuItem_Click(object? sender, System.EventArgs e)
    {
        DesktopApp.Shutdown();
    }

    private Mutex _mutex;

    private bool ExistLaunchedApp()
    {
        //https://stackoverflow.com/questions/14506406/wpf-single-instance-best-practices
        bool isOwned;
        _mutex = new Mutex(true, Directory.GetCurrentDirectory().ToHashSet().ToString(), out isOwned);
        EventWaitHandle eventWaitHandle = new EventWaitHandle(false, EventResetMode.AutoReset, "MainWindowWake");

        // So, R# would not give a warning that this variable is not used.
        GC.KeepAlive(_mutex);
        if (isOwned)
        {
            // Spawn a thread which will be waiting for our event
            var thread = new Thread(() =>
            {
                while (eventWaitHandle.WaitOne())
                {
                    //MainWindow.DispatcherQueue.TryEnqueue(() => MainWindow.Show());
                }
            });
            // It is important mark it as background otherwise it will prevent app from exiting.
            thread.IsBackground = true;
            thread.Start();
            return false;
        }
        // Notify other instance so it could bring itself to foreground.
        eventWaitHandle.Set();

        // Terminate this instance.

        return true;
    }
}
