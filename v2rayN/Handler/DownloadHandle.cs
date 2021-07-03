using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using v2rayN.Extension;
using v2rayN.Config;
using v2rayN.Properties;

namespace v2rayN.Handler
{
    /// <summary>
    ///Download
    /// </summary>
    class DownloadHandle
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
            domainList
        }
        public string downloadFileName;
        private readonly string nLatestUrl = "https://github.com/blackier/v2rayN/releases/latest";
        private const string nUrl = "https://github.com/blackier/v2rayN/releases/download/{0}/v2rayN.zip";
        private readonly string coreLatestUrl = "https://github.com/v2fly/v2ray-core/releases/latest";
        private const string coreUrl = "https://github.com/v2fly/v2ray-core/releases/download/{0}/v2ray-windows-{1}.zip";
        private readonly string geositeLatestUrl = "https://github.com/v2fly/domain-list-community/releases/latest";
        private const string geositeUrl = "https://github.com/v2fly/domain-list-community/releases/download/{0}/dlc.dat";

        #region Check for updates

        public async void CheckUpdateAsync(downloadType type)
        {
            Utils.SetSecurityProtocol();
            HttpClientHandler webRequestHandler = new HttpClientHandler
            {
                AllowAutoRedirect = false
            };
            HttpClient httpClient = new HttpClient(webRequestHandler);

            string url;
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
                url = geositeLatestUrl;
            }
            else
            {
                throw new ArgumentException("Type");
            }
            HttpResponseMessage response = await httpClient.GetAsync(url);
            if (response.StatusCode.ToString() == "Redirect")
            {
                responseHandler(type, response.Headers.Location.ToString());
            }
            else
            {
                Utils.SaveLog("StatusCode error: " + url);
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
                string filePath = Utils.GetPath("V2ray.exe");
                if (!File.Exists(filePath))
                {
                    string msg = string.Format(Utils.StringsRes.I18N("NotFoundCore"), @"https://github.com/v2fly/v2ray-core/releases");
                    //ShowMsg(true, msg);
                    return "";
                }

                Process p = new Process();
                p.StartInfo.FileName = filePath;
                p.StartInfo.Arguments = "-version";
                p.StartInfo.WorkingDirectory = Utils.StartupPath();
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
                Utils.SaveLog(ex.Message, ex);
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
                    message = string.Format(Utils.StringsRes.I18N("IsLatestCore"), curVersion);
                    string osBit = Environment.Is64BitProcess ? "64" : "32";
                    url = string.Format(coreUrl, version, osBit);
                }
                else if (type == downloadType.v2rayN)
                {
                    curVersion = FileVersionInfo.GetVersionInfo(Utils.GetExePath()).FileVersion.ToString();
                    message = string.Format(Utils.StringsRes.I18N("IsLatestN"), curVersion);
                    url = string.Format(nUrl, version);
                }
                else if (type == downloadType.domainList)
                {
                    url = string.Format(geositeUrl, version);
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
                Utils.SaveLog(ex.Message, ex);

                Error?.Invoke(this, new ErrorEventArgs(ex));
            }
        }

        #endregion

        #region Download 

        public WebClientEx DownloadFileAsync(string url, WebProxy webProxy, int downloadTimeout)
        {
            WebClientEx ws = new WebClientEx();
            try
            {
                Utils.SetSecurityProtocol();
                UpdateCompleted?.Invoke(this, new ResultEventArgs(false, Utils.StringsRes.I18N("Downloading")));

                progressPercentage = -1;
                totalBytesToReceive = 0;

                DownloadTimeout = downloadTimeout;
                if (webProxy != null)
                {
                    ws.Proxy = webProxy;// new WebProxy(Global.Loopback, Global.httpPort);
                }

                ws.DownloadFileCompleted += ws_DownloadFileCompleted;
                ws.DownloadProgressChanged += ws_DownloadProgressChanged;
                ws.DownloadFileAsync(new Uri(url), Utils.GetPath(downloadFileName));
            }
            catch (Exception ex)
            {
                Utils.SaveLog(ex.Message, ex);

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
                        ((WebClientEx)sender).CancelAsync();
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
                        ((WebClientEx)sender).Dispose();
                        TimeSpan ts = (DateTime.Now - totalDatetime);
                        string speed = string.Format("{0} M/s", (totalBytesToReceive / ts.TotalMilliseconds / 1000).ToString("#0.##"));
                        UpdateCompleted(this, new ResultEventArgs(true, speed));
                        return;
                    }

                    if (e.Error == null
                        || Utils.IsNullOrEmpty(e.Error.ToString()))
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
                Utils.SaveLog(ex.Message, ex);

                Error?.Invoke(this, new ErrorEventArgs(ex));
            }
        }

        /// <summary>
        /// DownloadString
        /// </summary> 
        /// <param name="url"></param>
        public void WebDownloadString(string url)
        {
            string source = string.Empty;
            try
            {
                Utils.SetSecurityProtocol();

                WebClientEx ws = new WebClientEx();
                ws.DownloadStringCompleted += Ws_DownloadStringCompleted;
                ws.DownloadStringAsync(new Uri(url));
            }
            catch (Exception ex)
            {
                Utils.SaveLog(ex.Message, ex);
            }
        }

        private void Ws_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                if (e.Error == null
                    || Utils.IsNullOrEmpty(e.Error.ToString()))
                {
                    string source = e.Result;
                    UpdateCompleted?.Invoke(this, new ResultEventArgs(true, source));
                }
                else
                {
                    throw e.Error;
                }
            }
            catch (Exception ex)
            {
                Utils.SaveLog(ex.Message, ex);

                Error?.Invoke(this, new ErrorEventArgs(ex));
            }
        }

        #endregion
    }
}
