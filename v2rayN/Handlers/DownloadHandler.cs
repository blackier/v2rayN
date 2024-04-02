using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using v2rayN.Extensions;

namespace v2rayN.Handlers;

/// <summary>
///Download
/// </summary>
class DownloadHandler
{
    public event EventHandler<ResultEventArgs> AbsoluteCompleted;

    public event EventHandler<ResultEventArgs> UpdateCompleted;

    public event ErrorEventHandler Error;

    public class ResultEventArgs : EventArgs
    {
        public bool Success;
        public string Msg;

        public ResultEventArgs(bool success, string msg)
        {
            this.Success = success;
            this.Msg = msg;
        }
    }

    private int progressPercentage = -1;
    private long totalBytesToReceive = 0;
    private DateTime totalDatetime = new DateTime();
    private int DownloadTimeout = -1;

    public enum downloadType
    {
        v2rayN,
        v2rayCore,
        domainList,
        ipList
    }
    public string downloadFileName;
    private readonly string nLatestUrl = "https://github.com/blackier/v2rayN/releases/latest";
    private const string nUrl = "https://github.com/blackier/v2rayN/releases/download/{0}/v2rayN.zip";
    private readonly string coreLatestUrl = "https://github.com/XTLS/Xray-core/releases/latest";
    private const string coreUrl = "https://github.com/XTLS/Xray-core/releases/download/{0}/Xray-windows-{1}.zip";
    private readonly string geositeLatestUrl = "https://github.com/v2fly/domain-list-community/releases/latest/download/dlc.dat";
    private const string geoipLastUrl = "https://github.com/v2fly/geoip/releases/latest/download/geoip.dat";

    #region Check for updates

    public async void CheckUpdateAsync(downloadType type)
    {
        HttpClientHandler webRequestHandler = new HttpClientHandler
        {
            AllowAutoRedirect = false
        };
        HttpClient httpClient = new HttpClient(webRequestHandler);

        string url = "";
        if (type == downloadType.v2rayCore)
        {
            url = coreLatestUrl;
        }
        else if (type == downloadType.v2rayN)
        {
            url = nLatestUrl;
        }
        else if (type == downloadType.domainList)
        {
            responseHandler(type, geositeLatestUrl);
        }
        else if (type == downloadType.ipList)
        {
            responseHandler(type, geoipLastUrl);
        }
        else
        {
            throw new ArgumentException("Type");
        }
        HttpResponseMessage response = await httpClient.GetAsync(url);
        if (response.StatusCode == HttpStatusCode.Redirect)
        {
            responseHandler(type, response.Headers.Location.ToString());
        }
        else
        {
            Log.SaveLog("StatusCode error: " + url);
            return;
        }
    }

    /// <summary>
    /// 获取V2RayCore版本
    /// </summary>
    public string getV2rayVersion()
    {
        try
        {
            string filePath = Misc.GetPath("V2ray.exe");
            if (!File.Exists(filePath))
            {
                string msg = string.Format(StringsRes.I18N("NotFoundCore"), @"https://github.com/v2fly/v2ray-core/releases");
                //ShowMsg(true, msg);
                return "";
            }

            Process p = new Process();
            p.StartInfo.FileName = filePath;
            p.StartInfo.Arguments = "-version";
            p.StartInfo.WorkingDirectory = Misc.StartupPath();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();
            p.WaitForExit(5000);
            string echo = p.StandardOutput.ReadToEnd();
            string version = Regex.Match(echo, "V2Ray ([0-9.]+) \\(").Groups[1].Value;
            return version;
        }

        catch (Exception ex)
        {
            Log.SaveLog(ex.Message, ex);
            return "";
        }
    }
    private void responseHandler(downloadType type, string redirectUrl)
    {
        try
        {
            string version = redirectUrl.Substring(redirectUrl.LastIndexOf("/", StringComparison.Ordinal) + 1);

            string curVersion = "";
            string message = "";
            string url;
            if (type == downloadType.v2rayCore)
            {
                curVersion = "v" + getV2rayVersion();
                message = string.Format(StringsRes.I18N("IsLatestCore"), curVersion);
                string osBit = Environment.Is64BitProcess ? "64" : "32";
                url = string.Format(coreUrl, version, osBit);
            }
            else if (type == downloadType.v2rayN)
            {
                curVersion = FileVersionInfo.GetVersionInfo(Misc.GetExePath()).FileVersion.ToString();
                message = string.Format(StringsRes.I18N("IsLatestN"), curVersion);
                url = string.Format(nUrl, version);
            }
            else if (type == downloadType.domainList)
            {
                url = redirectUrl;
            }
            else if (type == downloadType.ipList)
            {
                url = redirectUrl;
            }
            else
            {
                throw new ArgumentException("Type");
            }

            if (curVersion == version)
            {
                AbsoluteCompleted?.Invoke(this, new ResultEventArgs(false, message));
                return;
            }
            downloadFileName = url.Substring(url.LastIndexOf("/", StringComparison.Ordinal) + 1);

            AbsoluteCompleted?.Invoke(this, new ResultEventArgs(true, url));
        }
        catch (Exception ex)
        {
            Log.SaveLog(ex.Message, ex);

            Error?.Invoke(this, new ErrorEventArgs(ex));
        }
    }

    #endregion

    #region Download 

    public WebClient DownloadFileAsync(string url, WebProxy webProxy, int downloadTimeout)
    {
        WebClient ws = new WebClient();
        try
        {
            UpdateCompleted?.Invoke(this, new ResultEventArgs(false, StringsRes.I18N("Downloading")));

            progressPercentage = -1;
            totalBytesToReceive = 0;

            DownloadTimeout = downloadTimeout;
            if (webProxy != null)
            {
                ws.Proxy = webProxy;
            }

            ws.DownloadFileCompleted += ws_DownloadFileCompleted;
            ws.DownloadProgressChanged += ws_DownloadProgressChanged;
            ws.DownloadFileAsync(new Uri(url), Misc.GetPath(downloadFileName));
        }
        catch (Exception ex)
        {
            Log.SaveLog(ex.Message, ex);

            Error?.Invoke(this, new ErrorEventArgs(ex));
        }
        return ws;
    }

    void ws_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
        if (UpdateCompleted != null)
        {
            if (totalBytesToReceive == 0)
            {
                totalDatetime = DateTime.Now;
                totalBytesToReceive = e.BytesReceived;
                return;
            }
            totalBytesToReceive = e.BytesReceived;

            if (DownloadTimeout != -1)
            {
                if ((DateTime.Now - totalDatetime).TotalSeconds > DownloadTimeout)
                {
                    ((WebClient)sender).CancelAsync();
                }
            }
            if (progressPercentage != e.ProgressPercentage && e.ProgressPercentage % 10 == 0)
            {
                progressPercentage = e.ProgressPercentage;
                string msg = string.Format("...{0}%", e.ProgressPercentage);
                UpdateCompleted(this, new ResultEventArgs(false, msg));
            }
        }
    }
    void ws_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
    {
        try
        {
            if (UpdateCompleted != null)
            {
                if (e.Cancelled)
                {
                    ((WebClient)sender).Dispose();
                    TimeSpan ts = (DateTime.Now - totalDatetime);
                    string speed = string.Format("{0} M/s", (totalBytesToReceive / ts.TotalMilliseconds / 1000).ToString("#0.##"));
                    UpdateCompleted(this, new ResultEventArgs(true, speed));
                    return;
                }

                if (e.Error == null || Misc.IsNullOrEmpty(e.Error.ToString()))
                {
                    TimeSpan ts = (DateTime.Now - totalDatetime);
                    string speed = string.Format("{0} M/s", (totalBytesToReceive / ts.TotalMilliseconds / 1000).ToString("#0.##"));
                    UpdateCompleted(this, new ResultEventArgs(true, speed));
                }
                else
                {
                    throw e.Error;
                }
            }
        }
        catch (Exception ex)
        {
            Log.SaveLog(ex.Message, ex);

            Error?.Invoke(this, new ErrorEventArgs(ex));
        }
    }

    /// <summary>
    /// DownloadString
    /// </summary> 
    /// <param name="url"></param>
    public async void WebDownloadString(string url, WebProxy webProxy = null)
    {
        try
        {
            HttpClient httpClient = new(new HttpClientHandler
            {
                Proxy = webProxy,
                AllowAutoRedirect = false,
            });
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/119.0.6045.160 Safari/537.36");
            var result = await httpClient.GetStringAsync(url);

            if (!Misc.IsNullOrEmpty(result))
                UpdateCompleted?.Invoke(this, new ResultEventArgs(true, result));
        }
        catch (Exception ex)
        {
            Log.SaveLog(ex.Message, ex);

            Error?.Invoke(this, new ErrorEventArgs(ex));
        }
    }

    #endregion
}
