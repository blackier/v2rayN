using System;
using System.Threading;
using System.Windows.Forms;
using v2rayN.Forms;

namespace v2rayN;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
        AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);


        //AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

        if (!IsDuplicateInstance())
        {

            Log.SaveLog("v2rayN start up " + Misc.GetVersion());

            //设置语言环境
            string lang = Misc.RegReadValue(Global.MyRegPath, Global.MyRegKeyLanguage, "zh-Hans");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
        else
        {
            MsgBox.ShowWarning($"v2rayN is already running(v2rayN已经运行)");
        }
    }

    /// <summary> 
    /// 检查是否已在运行
    /// </summary> 
    public static bool IsDuplicateInstance()
    {
        //string name = "v2rayN";

        string name = Misc.GetExePath(); // Allow different locations to run
        name = name.Replace("\\", "/"); // https://stackoverflow.com/questions/20714120/could-not-find-a-part-of-the-path-error-while-creating-mutex
        
        Global.mutexObj = new Mutex(false, name, out bool bCreatedNew);
        return !bCreatedNew;
    }

    static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
    {
        Log.SaveLog("Application_ThreadException", e.Exception);
    }

    static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        Log.SaveLog("CurrentDomain_UnhandledException", (Exception)e.ExceptionObject);
    }
}
