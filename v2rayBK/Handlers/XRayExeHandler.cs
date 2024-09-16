using System.Diagnostics;
using v2rayBK.ViewModels;

namespace v2rayBK.Handlers;

/// <summary>
/// v2ray进程处理类
/// </summary>
internal class XRayExeHandler
{
    private List<string> lstV2ray = new() { "xray", "v2ray", "wv2ray", };
    private Process _process;

    public XRayExeHandler() { }

    /// <summary>
    /// 载入V2ray
    /// </summary>
    public void LoadV2ray(v2rayBKConfig config)
    {
        string fileName = Utils.GetPath("config.json");
        var ret = XRayConfigHandler.GenerateClientConfig(config, fileName, false, out string msg);
        App.PostLog(msg);
        if (ret)
            V2rayRestart();
    }

    /// <summary>
    /// 新建进程，生成测试配置并启动
    /// 返回新进程pid。
    /// </summary>
    public int LoadV2rayTestString(v2rayBKConfig config, List<int> _selecteds)
    {
        string configStr = XRayConfigHandler.GenerateClientSpeedTestConfigString(config, _selecteds);
        int pid = -1;
        if (!configStr.IsNullOrEmpty())
            pid = V2rayStartNew(configStr, "config_test.json");

        return pid;
    }

    public void V2rayRestart()
    {
        V2rayStop();
        V2rayStart();
    }

    public void V2rayStart()
    {
        try
        {
            string fileName = V2rayFindexe();
            if (fileName == "")
                return;

            Process p = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = fileName,
                    WorkingDirectory = Utils.StartupPath(),
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    StandardOutputEncoding = Encoding.UTF8,
                    Arguments = "run"
                }
            };
            p.OutputDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    App.PostLog(e.Data);
                }
            };
            p.Start();
            p.PriorityClass = ProcessPriorityClass.High;
            p.BeginOutputReadLine();
            //processId = p.Id;
            _process = p;
        }
        catch (Exception ex)
        {
            App.PostLog(ex.Message);
        }
    }

    public void V2rayStop()
    {
        try
        {
            if (_process != null)
            {
                KillProcess(_process);
                _process.Dispose();
                _process = null;
            }
            else
            {
                foreach (string vName in lstV2ray)
                {
                    Process[] existing = Process.GetProcessesByName(vName);
                    foreach (Process p in existing)
                    {
                        string path = p.MainModule.FileName;
                        if (path == $"{Utils.GetPath(vName)}.exe")
                        {
                            KillProcess(p);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            App.PostLog(ex.Message);
        }
    }

    public void V2rayStopPid(int pid)
    {
        try
        {
            Process _p = Process.GetProcessById(pid);
            KillProcess(_p);
        }
        catch (Exception ex)
        {
            App.PostLog(ex.Message);
        }
    }

    private string V2rayFindexe()
    {
        //查找v2ray文件是否存在
        string fileName = string.Empty;
        foreach (string name in lstV2ray)
        {
            string vName = $"{name}.exe";
            vName = Utils.GetPath(vName);
            if (File.Exists(vName))
            {
                fileName = vName;
                break;
            }
        }
        if (Utils.IsNullOrEmpty(fileName))
        {
            App.PostLog("NotFoundCore");
        }
        return fileName;
    }

    /// <summary>
    /// V2ray启动，新建进程，传入配置字符串
    /// </summary>
    private int V2rayStartNew(string configStr, string configFileName)
    {
        try
        {
            string fileName = V2rayFindexe();
            if (fileName == "")
                return -1;

            Process p = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = fileName,
                    Arguments = $"run -c {Path.Combine(Utils.StartupPath(), configFileName)}",
                    WorkingDirectory = Utils.StartupPath(),
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    StandardOutputEncoding = Encoding.UTF8
                }
            };
            p.OutputDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    App.PostLog(e.Data);
                }
            };

            File.WriteAllText(Path.Combine(Utils.StartupPath(), configFileName), configStr);

            p.Start();
            p.BeginOutputReadLine();

            return p.Id;
        }
        catch (Exception ex)
        {
            App.PostLog(ex.Message);
            return -1;
        }
    }

    private void KillProcess(Process p)
    {
        try
        {
            p.CloseMainWindow();
            p.WaitForExit(100);
            if (!p.HasExited)
            {
                p.Kill();
                p.WaitForExit(100);
            }
        }
        catch (Exception ex)
        {
            App.PostLog(ex.Message);
        }
    }
}
