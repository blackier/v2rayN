using System;
using Avalonia;

namespace v2rayBK;

internal sealed class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        // 管理员权限重启，非单例
        _rebootAs = args.Contains(Global.RebootAs);
        if (ExistLaunchedApp(!_rebootAs))
            return;
        BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
    }

    internal static bool _rebootAs = false;

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp() =>
        AppBuilder.Configure<App>().UsePlatformDetect()
#if DEBUG
        .WithDeveloperTools()
#endif
        .WithInterFont().LogToTrace();

    internal static Mutex _mutex;
    internal static EventWaitHandle _eventWaitHandle;

    private static bool ExistLaunchedApp(bool isSingle = true)
    {
        //https://stackoverflow.com/questions/14506406/wpf-single-instance-best-practices
        bool isOwned;
        _mutex = new Mutex(true, Directory.GetCurrentDirectory().ToHashSet().ToString()[..5], out isOwned);
        _eventWaitHandle = new EventWaitHandle(false, EventResetMode.AutoReset, "MainWindowWake");

        if (isOwned)
        {
            GC.KeepAlive(_mutex);
            return false;
        }
        // Notify other instance so it could bring itself to foreground.
        if (isSingle)
            _eventWaitHandle.Set();
        return isSingle;
    }
}
