using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace v2rayBK.Handlers;

public class PACHandler
{
    public static void ShowMsg(string msg)
    {
        App.PostLog(msg);
    }

    // https://learn.microsoft.com/zh-cn/dotnet/api/system.net.httplistener.begingetcontext?view=net-8.0
    private static HttpListener _listener;

    public static void StopListenner()
    {
        ShowMsg("pac listenner stop");
        _listener?.Stop();
        _listener?.Close();
        _listener = null;
    }

    public static void StartListener(string[] prefixes)
    {
        ShowMsg("pac listenner start");
        if (_listener != null)
        {
            if (_listener.IsListening)
                return;
            _listener.Stop();
            _listener.Close();
            _listener = null;
        }
        _listener = new HttpListener();
        foreach (string s in prefixes)
        {
            _listener.Prefixes.Add(s);
        }
        _listener.Start();
        IAsyncResult result = _listener.BeginGetContext(new AsyncCallback(ListenerCallback), _listener);
        // Applications can do some work here while waiting for the
        // request. If no work can be done until you have processed a request,
        // use a wait handle to prevent this thread from terminating
        // while the asynchronous operation completes.

        //Console.WriteLine("Waiting for request to be processed asyncronously.");
        //result.AsyncWaitHandle.WaitOne();
        //Console.WriteLine("Request processed asyncronously.");
        //listener.Close();
    }

    private static void ListenerCallback(IAsyncResult result)
    {
        ShowMsg("pac listenner callback");
        HttpListener listener = (HttpListener)result.AsyncState;
        if (listener == null || !listener.IsListening)
        {
            ShowMsg("pac listener is null, need restart listener");
            _listener = null;
            return;
        }

        try
        {
            // Call EndGetContext to complete the asynchronous operation.
            HttpListenerContext context = listener.EndGetContext(result);
            HttpListenerRequest request = context.Request;
            // Obtain a response object.
            HttpListenerResponse response = context.Response;
            // Construct a response.
            string responseString =
                @$"
var proxy = 'SOCKS5 127.0.0.1:10808; SOCKS 127.0.0.1:10808';
var direct = 'DIRECT';

function FindProxyForURL(url, host) {{
    return proxy;
}}
";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            // Get a response stream and write the response to it.
            response.ContentType = "application/x-ns-proxy-autoconfig";
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            // You must close the output stream.
            output.Close();

            // Again
            listener.BeginGetContext(new AsyncCallback(ListenerCallback), listener);
        }
        catch (Exception e)
        {
            ShowMsg(e.Message);
        }
    }
}
