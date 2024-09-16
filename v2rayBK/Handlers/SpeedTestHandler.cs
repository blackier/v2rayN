using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using v2rayBK.ViewModels;

namespace v2rayBK.Handlers;

internal class SpeedTestHandler
{
    public static void RunRealPing(v2rayBKConfig config, List<int> selecteds)
    {
        XRayExeHandler handler = new();
        int pid = handler.LoadV2rayTestString(config, selecteds);
        if (pid < 0)
            return;
        try
        {
            List<Task> tasks = new List<Task>();
            foreach (int itemIndex in selecteds)
            {
                var server = config.GetSelectedServer(itemIndex);
                tasks.Add(
                    Task.Run(() =>
                    {
                        try
                        {
                            WebProxy webProxy = new WebProxy(Global.Loopback, server!.SpeedTestPort);
                            int responseTime = -1;
                            string result = GetRealPingTime(config.SpeedPingTestUrl, webProxy, out responseTime);
                            if (result.IsNullOrEmpty())
                                result = $"{responseTime} ms";
                            App.PostTask(() => server.TestResult = result);
                        }
                        catch (Exception ex)
                        {
                            App.PostLog(ex.Message);
                        }
                    })
                );
            }
            Task.WaitAll(tasks.ToArray());
        }
        catch (Exception ex)
        {
            App.PostLog(ex.Message);
        }

        handler.V2rayStopPid(pid);
    }

    public static int GetTcpingTime(string url, int port)
    {
        int responseTime = -1;
        try
        {
            if (!IPAddress.TryParse(url, out IPAddress ipAddress))
            {
                IPHostEntry ipHostInfo = System.Net.Dns.GetHostEntry(url);
                ipAddress = ipHostInfo.AddressList[0];
            }

            Stopwatch timer = new Stopwatch();
            timer.Start();

            IPEndPoint endPoint = new IPEndPoint(ipAddress, port);
            Socket clientSocket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            IAsyncResult result = clientSocket.BeginConnect(endPoint, null, null);
            if (!result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(5)))
                throw new TimeoutException("connect timeout (5s): " + url);
            clientSocket.EndConnect(result);

            timer.Stop();
            responseTime = timer.Elapsed.Milliseconds;
            clientSocket.Close();
        }
        catch (Exception ex)
        {
            App.PostLog(ex.Message);
        }
        return responseTime;
    }

    public static string GetRealPingTime(string url, WebProxy webProxy, out int responseTime)
    {
        string msg = string.Empty;
        responseTime = -1;
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Proxy = webProxy;
            request.Timeout = (int)TimeSpan.FromSeconds(5).TotalMilliseconds;

            Stopwatch timer = new Stopwatch();
            timer.Start();

            var response = (HttpWebResponse)request.GetResponse();

            timer.Stop();
            responseTime = timer.Elapsed.Milliseconds;

            if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.NoContent)
            {
                msg = response.StatusDescription;
            }
        }
        catch (Exception ex)
        {
            App.PostLog(ex.Message);
            msg = ex.Message;
        }
        return msg;
    }
}
