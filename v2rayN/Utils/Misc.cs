﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Serialization;
using Microsoft.Win32;
using v2rayN.Extensions;
using v2rayN.Utils;

namespace v2rayN.Utils;

public class Misc
{
    /// <summary>
    /// 获取嵌入文本资源
    /// </summary>
    /// <param name="res"></param>
    /// <returns></returns>
    public static string GetEmbedText(string res)
    {
        string result = string.Empty;

        try
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(res))
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }
        }
        catch { }
        return result;
    }

    /// <summary>
    /// 取得存储资源
    /// </summary>
    /// <returns></returns>
    public static string LoadResource(string res)
    {
        string result = string.Empty;

        try
        {
            using (StreamReader reader = new StreamReader(res))
            {
                result = reader.ReadToEnd();
            }
        }
        catch { }
        return result;
    }

    /// <summary>
    /// List<string>转逗号分隔的字符串
    /// </summary>
    /// <param name="lst"></param>
    /// <returns></returns>
    public static string List2String(List<string> lst, bool wrap = false)
    {
        try
        {
            if (wrap)
            {
                return string.Join("," + Environment.NewLine, lst.ToArray());
            }
            else
            {
                return string.Join(",", lst.ToArray());
            }
        }
        catch
        {
            return string.Empty;
        }
    }

    /// <summary>
    /// 逗号分隔的字符串,转List<string>
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static List<string> String2List(string str)
    {
        try
        {
            str = str.Replace(Environment.NewLine, "");
            return new List<string>(str.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries));
        }
        catch
        {
            return new List<string>();
        }
    }

    /// <summary>
    /// Base64编码
    /// </summary>
    /// <param name="plainText"></param>
    /// <returns></returns>
    public static string Base64Encode(string plainText)
    {
        try
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }
        catch (Exception ex)
        {
            Log.SaveLog("Base64Encode", ex);
            return string.Empty;
        }
    }

    /// <summary>
    /// Base64解码
    /// </summary>
    /// <param name="plainText"></param>
    /// <returns></returns>
    public static string Base64Decode(string plainText)
    {
        try
        {
            plainText = plainText
                .Trim()
                .Replace(Environment.NewLine, "")
                .Replace("\n", "")
                .Replace("\r", "")
                .Replace('_', '/')
                .Replace('-', '+')
                .Replace(" ", "");

            if (plainText.Length % 4 > 0)
            {
                plainText = plainText.PadRight(plainText.Length + 4 - plainText.Length % 4, '=');
            }

            byte[] data = Convert.FromBase64String(plainText);
            return Encoding.UTF8.GetString(data);
        }
        catch (Exception ex)
        {
            Log.SaveLog("Base64Decode", ex);
            return string.Empty;
        }
    }

    public static string UrlEncode(string url)
    {
        return Uri.EscapeDataString(url);
        //return  HttpUtility.UrlEncode(url);
    }

    public static string UrlDecode(string url)
    {
        return Uri.UnescapeDataString(url);
        //return HttpUtility.UrlDecode(url);
    }

    public static NameValueCollection ParseQueryString(string query)
    {
        var result = new NameValueCollection(StringComparer.OrdinalIgnoreCase);
        if (IsNullOrEmpty(query))
        {
            return result;
        }

        var parts = query[1..].Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var part in parts)
        {
            var keyValue = part.Split(['=']);
            if (keyValue.Length != 2)
            {
                continue;
            }
            var key = Uri.UnescapeDataString(keyValue[0]);
            var val = Uri.UnescapeDataString(keyValue[1]);

            if (result[key] is null)
            {
                result.Add(key, val);
            }
        }

        return result;
    }

    /// <summary>
    /// 转Int
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static int ToInt(object obj)
    {
        try
        {
            Type typ = obj.GetType();
            if (typ == typeof(JsonElement))
                return Convert.ToInt32(obj.ToString());

            return Convert.ToInt32(obj);
        }
        catch
        {
            return 0;
        }
    }

    public static string ToString(object obj)
    {
        try
        {
            return (obj == null ? string.Empty : obj.ToString());
        }
        catch
        {
            return string.Empty;
        }
    }

    /// <summary>
    /// byte 转成 有两位小数点的 方便阅读的数据
    ///     比如 2.50 MB
    /// </summary>
    /// <param name="amount">bytes</param>
    /// <param name="result">转换之后的数据</param>
    /// <param name="unit">单位</param>
    public static void ToHumanReadable(ulong amount, out double result, out string unit)
    {
        uint factor = 1024u;
        ulong KBs = amount / factor;
        if (KBs > 0)
        {
            // multi KB
            ulong MBs = KBs / factor;
            if (MBs > 0)
            {
                // multi MB
                ulong GBs = MBs / factor;
                if (GBs > 0)
                {
                    // multi GB
                    /*ulong TBs = GBs / factor;
                    if (TBs > 0)
                    {
                        // 你是魔鬼吗？ 用这么多流量
                        result = TBs + GBs % factor / (factor + 0.0);
                        unit = "TB";
                        return;
                    }*/
                    result = GBs + MBs % factor / (factor + 0.0);
                    unit = "GB";
                    return;
                }
                result = MBs + KBs % factor / (factor + 0.0);
                unit = "MB";
                return;
            }
            result = KBs + amount % factor / (factor + 0.0);
            unit = "KB";
            return;
        }
        else
        {
            result = amount;
            unit = "B";
        }
    }

    public static string HumanFy(ulong amount)
    {
        ToHumanReadable(amount, out double result, out string unit);
        return $"{string.Format("{0:f1}", result)} {unit}";
    }

    public static void DedupServerList(
        List<Config.ProfileItem> source,
        out List<Config.ProfileItem> result,
        bool keepOlder
    )
    {
        List<Config.ProfileItem> list = new List<Config.ProfileItem>();
        if (!keepOlder)
        {
            source.Reverse(); // Remove the early items first
        }

        bool _isAdded(Config.ProfileItem o, Config.ProfileItem n)
        {
            return o.configVersion == n.configVersion
                && o.configType == n.configType
                && o.address == n.address
                && o.port == n.port
                && o.id == n.id
                && o.alterId == n.alterId
                && o.security == n.security
                && o.network == n.network
                && o.headerType == n.headerType
                && o.requestHost == n.requestHost
                && o.path == n.path
                && o.streamSecurity == n.streamSecurity;
            // skip (will remove) different remarks
        }
        foreach (Config.ProfileItem item in source)
        {
            if (!list.Exists(i => _isAdded(i, item)))
            {
                list.Add(item);
            }
        }
        if (!keepOlder)
        {
            list.Reverse();
        }

        result = list;
    }

    /// <summary>
    /// 判断输入的是否是数字
    /// </summary>
    /// <param name="oText"></param>
    /// <returns></returns>
    public static bool IsNumberic(string oText)
    {
        try
        {
            int var1 = ToInt(oText);
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// 文本
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static bool IsNullOrEmpty(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return true;
        }
        if (text.Equals("null"))
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// 验证IP地址是否合法
    /// </summary>
    /// <param name="ip"></param>
    public static bool IsIP(string ip)
    {
        //如果为空
        if (IsNullOrEmpty(ip))
        {
            return false;
        }

        //清除要验证字符串中的空格
        //ip = ip.TrimEx();
        //可能是CIDR
        if (ip.IndexOf(@"/") > 0)
        {
            string[] cidr = ip.Split('/');
            if (cidr.Length == 2)
            {
                if (!IsNumberic(cidr[0]))
                {
                    return false;
                }
                ip = cidr[0];
            }
        }

        //模式字符串
        string pattern = @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$";

        //验证
        return IsMatch(ip, pattern);
    }

    public static bool IsIpv6(string ip)
    {
        if (IPAddress.TryParse(ip, out IPAddress? address))
        {
            return address.AddressFamily switch
            {
                AddressFamily.InterNetwork => false,
                AddressFamily.InterNetworkV6 => true,
                _ => false,
            };
        }
        return false;
    }

    /// <summary>
    /// 验证Domain地址是否合法
    /// </summary>
    /// <param name="domain"></param>
    public static bool IsDomain(string domain)
    {
        //如果为空
        if (IsNullOrEmpty(domain))
        {
            return false;
        }

        //清除要验证字符串中的空格
        //domain = domain.TrimEx();

        //模式字符串
        string pattern = @"^(?=^.{3,255}$)[a-zA-Z0-9][-a-zA-Z0-9]{0,62}(\.[a-zA-Z0-9][-a-zA-Z0-9]{0,62})+$";

        //验证
        return IsMatch(domain, pattern);
    }

    /// <summary>
    /// 验证输入字符串是否与模式字符串匹配，匹配返回true
    /// </summary>
    /// <param name="input">输入字符串</param>
    /// <param name="pattern">模式字符串</param>
    public static bool IsMatch(string input, string pattern)
    {
        return Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase);
    }

    private static string autoRunName = "v2rayNAutoRun";
    private static string autoRunRegPath => @"Software\Microsoft\Windows\CurrentVersion\Run"; //if (Environment.Is64BitProcess)//{//    return @"Software\Microsoft\Windows\CurrentVersion\Run";//}//else//{//    return @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Run";//}

    /// <summary>
    /// 开机自动启动
    /// </summary>
    /// <param name="run"></param>
    /// <returns></returns>
    public static void SetAutoRun(bool run)
    {
        try
        {
            string exePath = GetExePath();
            RegWriteValue(autoRunRegPath, autoRunName, run ? exePath : "");
        }
        catch { }
    }

    /// <summary>
    /// 是否已经设置开机自动启动
    /// </summary>
    /// <returns></returns>
    public static bool IsAutoRun()
    {
        try
        {
            string value = RegReadValue(autoRunRegPath, autoRunName, "");
            string exePath = GetExePath();
            if (value?.Equals(exePath) == true)
            {
                return true;
            }
        }
        catch { }
        return false;
    }

    /// <summary>
    /// 获取启动了应用程序的可执行文件的路径
    /// </summary>
    /// <returns></returns>
    public static string GetPath(string fileName)
    {
        string startupPath = StartupPath();
        if (IsNullOrEmpty(fileName))
        {
            return startupPath;
        }
        return Path.Combine(startupPath, fileName);
    }

    /// <summary>
    /// 获取启动了应用程序的可执行文件的路径及文件名
    /// </summary>
    /// <returns></returns>
    public static string GetExePath()
    {
        return Application.ExecutablePath;
    }

    public static string StartupPath()
    {
        return Application.StartupPath;
    }

    public static string GetRealExeDir()
    {
        return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Interoperability",
        "CA1416:Validate platform compatibility",
        Justification = "<Pending>"
    )]
    public static string RegReadValue(string path, string name, string def)
    {
        RegistryKey regKey = null;
        try
        {
            regKey = Registry.CurrentUser.OpenSubKey(path, false);
            string value = regKey?.GetValue(name) as string;
            if (IsNullOrEmpty(value))
            {
                return def;
            }
            else
            {
                return value;
            }
        }
        catch { }
        finally
        {
            regKey?.Close();
        }
        return def;
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Interoperability",
        "CA1416:Validate platform compatibility",
        Justification = "<Pending>"
    )]
    public static void RegWriteValue(string path, string name, string value)
    {
        RegistryKey regKey = null;
        try
        {
            regKey = Registry.CurrentUser.CreateSubKey(path);
            if (IsNullOrEmpty(value))
            {
                regKey?.DeleteValue(name, false);
            }
            else
            {
                regKey?.SetValue(name, value);
            }
        }
        catch { }
        finally
        {
            regKey?.Close();
        }
    }

    /// <summary>
    /// Ping
    /// </summary>
    /// <param name="host"></param>
    /// <returns></returns>
    public static long Ping(string host)
    {
        long roundtripTime = -1;
        try
        {
            int timeout = 30;
            int echoNum = 2;
            Ping pingSender = new Ping();
            for (int i = 0; i < echoNum; i++)
            {
                PingReply reply = pingSender.Send(host, timeout);
                if (reply.Status == IPStatus.Success)
                {
                    if (reply.RoundtripTime < 0)
                    {
                        continue;
                    }
                    if (roundtripTime < 0 || reply.RoundtripTime < roundtripTime)
                    {
                        roundtripTime = reply.RoundtripTime;
                    }
                }
            }
        }
        catch
        {
            return -1;
        }
        return roundtripTime;
    }

    /// <summary>
    /// 取得本机 IP Address
    /// </summary>
    /// <returns></returns>
    public static List<string> GetHostIPAddress()
    {
        List<string> lstIPAddress = new List<string>();
        try
        {
            IPHostEntry IpEntry = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ipa in IpEntry.AddressList)
            {
                if (ipa.AddressFamily == AddressFamily.InterNetwork)
                {
                    lstIPAddress.Add(ipa.ToString());
                }
            }
        }
        catch { }
        return lstIPAddress;
    }

    public static int GetFreePort()
    {
        TcpListener l = new TcpListener(IPAddress.Loopback, 0);
        l.Start();
        var port = ((IPEndPoint)l.LocalEndpoint).Port;
        l.Stop();
        return port;
    }

    /// <summary>
    /// 取得版本
    /// </summary>
    /// <returns></returns>
    public static string GetVersion()
    {
        try
        {
            string location = GetExePath();
            return string.Format(
                "v2rayN - V{0} - {1}",
                FileVersionInfo.GetVersionInfo(location).FileVersion.ToString(),
                File.GetLastWriteTime(location).ToString("yyyy/MM/dd")
            );
        }
        catch
        {
            return string.Empty;
        }
    }

    /// <summary>
    /// 深度拷贝
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static T DeepCopy<T>(T obj)
    {
        return Json.FromJson<T>(Json.ToJson(obj));
    }

    /// <summary>
    /// 获取剪贴板数
    /// </summary>
    /// <returns></returns>
    public static string GetClipboardData()
    {
        string strData = string.Empty;
        try
        {
            IDataObject data = Clipboard.GetDataObject();
            if (data.GetDataPresent(DataFormats.Text))
            {
                strData = data.GetData(DataFormats.Text).ToString();
            }
            return strData;
        }
        catch { }
        return strData;
    }

    /// <summary>
    /// 拷贝至剪贴板
    /// </summary>
    /// <returns></returns>
    public static void SetClipboardData(string strData)
    {
        try
        {
            Clipboard.SetText(strData);
        }
        catch { }
    }

    /// <summary>
    /// 取得GUID
    /// </summary>
    /// <returns></returns>
    public static string GetGUID(bool full = true)
    {
        try
        {
            if (full)
            {
                return Guid.NewGuid().ToString("D");
            }
            else
            {
                return BitConverter.ToInt64(Guid.NewGuid().ToByteArray(), 0).ToString();
            }
        }
        catch (Exception ex) { }
        return string.Empty;
    }

    // return path to store temporary files
    public static string GetTempPath(string filename = "")
    {
        string _tempPath = Path.Combine(StartupPath(), "guiTemps");
        if (!Directory.Exists(_tempPath))
        {
            Directory.CreateDirectory(_tempPath);
        }
        if (Misc.IsNullOrEmpty(filename))
        {
            return _tempPath;
        }
        else
        {
            return Path.Combine(_tempPath, filename);
        }
    }
}
