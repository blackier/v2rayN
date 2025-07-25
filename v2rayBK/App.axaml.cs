﻿using System;
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
    private static IHost _host = Host.CreateDefaultBuilder()
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
                services.AddTransient<RoutingPage>();
                services.AddTransient<SettingsPage>();
                // ViewModels
                services.AddSingleton<v2rayBKConfig>(v2rayBKConfig.LoadConfig() ?? new());
                services.AddSingleton<MainWindowViewModel>();
                services.AddSingleton<HomePageViewModel>();
                services.AddTransient<RoutingPageViewModel>();
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
        if (Design.IsDesignMode)
        {
            RequestedThemeVariant = ThemeVariant.Dark;
        }
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
            DesktopApp.ShutdownRequested += DesktopApp_ShutdownRequested;
        }

        base.OnFrameworkInitializationCompleted();
    }

    private async void DesktopApp_Startup(object? sender, ControlledApplicationLifetimeStartupEventArgs e)
    {
        await _host.StartAsync();

        // 主题
        switch (v2rayBKConfig.AppTheme)
        {
            case AppTheme.Dark:
                RequestedThemeVariant = ThemeVariant.Dark;
                break;
            case AppTheme.Light:
                RequestedThemeVariant = ThemeVariant.Light;
                break;
            default:
                break;
        }

        // Line below is needed to remove Avalonia data validation.
        // Without this line you will get duplicate validations from both Avalonia and CT
        BindingPlugins.DataValidators.RemoveAt(0);
        DesktopApp.MainWindow = MainWindow;

        // 自启动
        GetRequiredService<HomePage>();
        v2rayBKConfig.StartServer();
        LoadTrayIcon();
    }

    private void Desktop_Stop()
    {
        if (_host == null)
            return;
        GetRequiredService<v2rayBKConfig>().Close();
        _host.StopAsync().Wait();
        _host.Dispose();
        _host = null;
    }

    private void Desktop_Exit(object? sender, ControlledApplicationLifetimeExitEventArgs e)
    {
        Desktop_Stop();
    }

    private void DesktopApp_ShutdownRequested(object? sender, ShutdownRequestedEventArgs e)
    {
        Desktop_Stop();
        DesktopApp.Shutdown();
    }

    public static App Get()
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
        _mutex = new Mutex(true, Directory.GetCurrentDirectory().ToHashSet().ToString()[..5], out isOwned);
        EventWaitHandle eventWaitHandle = new EventWaitHandle(false, EventResetMode.AutoReset, "MainWindowWake");

        if (isOwned)
        {
            GC.KeepAlive(_mutex);
            var thread = new Thread(() =>
            {
                while (eventWaitHandle.WaitOne())
                {
                    PostTask(() => MainWindow.ShowWindow());
                }
            });
            // It is important mark it as background otherwise it will prevent app from exiting.
            thread.IsBackground = true;
            thread.Start();
            return false;
        }
        // Notify other instance so it could bring itself to foreground.
        eventWaitHandle.Set();
        return true;
    }
}
