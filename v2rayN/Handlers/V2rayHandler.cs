﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using v2rayN.Config;

namespace v2rayN.Handlers;

/// <summary>
/// 消息委托
/// </summary>
/// <param name="notify">是否显示在托盘区</param>
/// <param name="msg">内容</param>
public delegate void ProcessDelegate(bool notify, string msg);

/// <summary>
/// v2ray进程处理类
/// </summary>
class v2rayHandler
{
    private static string v2rayConfigRes = Global.v2rayConfigFileName;
    private List<string> lstV2ray;
    public event ProcessDelegate ProcessEvent;

    //private int processId = 0;
    private Process _process;

    public v2rayHandler()
    {
        lstV2ray = new List<string> { "xray", "v2ray", "wv2ray", };
    }

    /// <summary>
    /// 载入V2ray
    /// </summary>
    public void LoadV2ray(Config.V2RayNConfig config)
    {
        if (Global.reloadV2ray)
        {
            string fileName = Misc.GetPath(v2rayConfigRes);
            if (v2rayConfigHandler.GenerateClientConfig(config, fileName, false, out string msg) != 0)
            {
                ShowMsg(false, msg);
            }
            else
            {
                ShowMsg(true, msg);
                V2rayRestart();
            }
        }
    }

    /// <summary>
    /// 新建进程，载入V2ray配置文件字符串
    /// 返回新进程pid。
    /// </summary>
    public int LoadV2rayConfigString(Config.V2RayNConfig config, List<int> _selecteds)
    {
        int pid = -1;
        string configStr = v2rayConfigHandler.GenerateClientSpeedtestConfigString(config, _selecteds, out string msg);
        if (configStr == "")
        {
            ShowMsg(false, msg);
        }
        else
        {
            ShowMsg(false, msg);
            pid = V2rayStartNew(configStr);
            //V2rayRestart();
            // start with -config
        }
        return pid;
    }

    /// <summary>
    /// V2ray重启
    /// </summary>
    private void V2rayRestart()
    {
        V2rayStop();
        V2rayStart();
    }

    /// <summary>
    /// V2ray停止
    /// </summary>
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
                        if (path == $"{Misc.GetPath(vName)}.exe")
                        {
                            KillProcess(p);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Log.SaveLog(ex.Message, ex);
        }
    }

    /// <summary>
    /// V2ray停止
    /// </summary>
    public void V2rayStopPid(int pid)
    {
        try
        {
            Process _p = Process.GetProcessById(pid);
            KillProcess(_p);
        }
        catch (Exception ex)
        {
            Log.SaveLog(ex.Message, ex);
        }
    }

    private string V2rayFindexe()
    {
        //查找v2ray文件是否存在
        string fileName = string.Empty;
        //lstV2ray.Reverse();
        foreach (string name in lstV2ray)
        {
            string vName = string.Format("{0}.exe", name);
            vName = Misc.GetPath(vName);
            if (File.Exists(vName))
            {
                fileName = vName;
                break;
            }
        }
        if (Misc.IsNullOrEmpty(fileName))
        {
            string msg = string.Format(
                StringsRes.I18N("NotFoundCore"),
                @"https://github.com/v2fly/v2ray-core/releases"
            );
            ShowMsg(false, msg);
        }
        return fileName;
    }

    /// <summary>
    /// V2ray启动
    /// </summary>
    private void V2rayStart()
    {
        ShowMsg(false, string.Format(StringsRes.I18N("StartService"), DateTime.Now.ToString()));

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
                    WorkingDirectory = Misc.StartupPath(),
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    StandardOutputEncoding = Encoding.UTF8,
                    Arguments = "run"
                }
            };
            p.OutputDataReceived += new DataReceivedEventHandler(
                (sender, e) =>
                {
                    if (!String.IsNullOrEmpty(e.Data))
                    {
                        string msg = e.Data + Environment.NewLine;
                        ShowMsg(false, msg);
                    }
                }
            );
            p.Start();
            p.PriorityClass = ProcessPriorityClass.High;
            p.BeginOutputReadLine();
            //processId = p.Id;
            _process = p;

            if (p.WaitForExit(1000))
            {
                throw new Exception(p.StandardError.ReadToEnd());
            }
        }
        catch (Exception ex)
        {
            Log.SaveLog(ex.Message, ex);
            string msg = ex.Message;
            ShowMsg(true, msg);
        }
    }

    /// <summary>
    /// V2ray启动，新建进程，传入配置字符串
    /// </summary>
    private int V2rayStartNew(string configStr)
    {
        ShowMsg(false, string.Format(StringsRes.I18N("StartService"), DateTime.Now.ToString()));

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
                    Arguments = $"run -c {Path.Combine(Misc.GetRealExeDir(), "config_test.json")}",
                    WorkingDirectory = Misc.StartupPath(),
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    StandardOutputEncoding = Encoding.UTF8
                }
            };
            p.OutputDataReceived += new DataReceivedEventHandler(
                (sender, e) =>
                {
                    if (!String.IsNullOrEmpty(e.Data))
                    {
                        string msg = e.Data + Environment.NewLine;
                        ShowMsg(false, msg);
                    }
                }
            );
            File.WriteAllText(Path.Combine(Misc.GetRealExeDir(), "config_test.json"), configStr);

            p.Start();
            p.BeginOutputReadLine();

            if (p.WaitForExit(1000))
            {
                throw new Exception(p.StandardError.ReadToEnd());
            }
            return p.Id;
        }
        catch (Exception ex)
        {
            Log.SaveLog(ex.Message, ex);
            string msg = ex.Message;
            ShowMsg(false, msg);
            return -1;
        }
    }

    /// <summary>
    /// 消息委托
    /// </summary>
    /// <param name="updateToTrayTooltip">是否更新托盘图标的工具提示</param>
    /// <param name="msg">输出到日志框</param>
    private void ShowMsg(bool updateToTrayTooltip, string msg)
    {
        ProcessEvent?.Invoke(updateToTrayTooltip, msg);
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
            Log.SaveLog(ex.Message, ex);
        }
    }
}
