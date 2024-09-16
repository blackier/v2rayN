using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace v2rayBK.Common;

internal class Misc
{
    private static string autoRunName = "v2rayBKAutoRun";
    private static string autoRunRegPath = @"Software\Microsoft\Windows\CurrentVersion\Run";

    public static string? RegReadValue(string path, string name, string def)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            return null;

        RegistryKey? regKey = null;
        try
        {
            regKey = Registry.CurrentUser.OpenSubKey(path, false);
            string? value = regKey?.GetValue(name) as string;
            if (Utils.IsNullOrEmpty(value))
            {
                return def;
            }
            else
            {
                return value;
            }
        }
        catch (Exception ex)
        {
            App.PostLog(ex.Message);
        }
        finally
        {
            regKey?.Close();
        }
        return def;
    }

    public static void RegWriteValue(string path, string name, object value)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            return;

        RegistryKey? regKey = null;
        try
        {
            regKey = Registry.CurrentUser.CreateSubKey(path);
            if (Utils.IsNullOrEmpty(value.ToString()))
            {
                regKey?.DeleteValue(name, false);
            }
            else
            {
                regKey?.SetValue(name, value);
            }
        }
        catch (Exception ex)
        {
            App.PostLog(ex.Message);
        }
        finally
        {
            regKey?.Close();
        }
    }

    public static void SetAutoRun(bool run)
    {
        try
        {
            string exePath = Utils.GetExePath();
            RegWriteValue(autoRunRegPath, autoRunName, run ? exePath : "");
        }
        catch { }
    }

    public static bool IsAutoRun()
    {
        try
        {
            string? value = RegReadValue(autoRunRegPath, autoRunName, "");
            string exePath = Utils.GetExePath();
            if (value?.Equals(exePath) == true)
            {
                return true;
            }
        }
        catch { }
        return false;
    }
}
