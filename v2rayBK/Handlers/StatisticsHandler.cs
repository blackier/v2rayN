using v2rayBK.V2RayAPI;
using v2rayBK.ViewModels;

namespace v2rayBK.Handlers;

class StatisticsHandler
{
    private v2rayBKConfig _config;
    private StatsServiceClient _client;
    private bool _isRuning;
    private Task _loopTask;

    public StatisticsHandler(v2rayBKConfig config)
    {
        _config = config;
        _isRuning = false;
    }

    public void Start()
    {
        if (_isRuning)
            return;
        _client = new StatsServiceClient($"{Global.Loopback}:{GlobalEx.v2rayApiPort}");

        _isRuning = true;
        _loopTask = new Task(() => Run());
        _loopTask.Start();
    }

    public void Close()
    {
        try
        {
            _isRuning = false;
            if (_loopTask?.Status == TaskStatus.Running)
            {
                _loopTask.Wait();
            }
            _client.Shutdown();
        }
        catch (Exception ex)
        {
            App.PostLog(ex.Message);
        }
    }

    public void Run()
    {
        while (_isRuning)
        {
            try
            {
                Thread.Sleep(1000);

                var server = _config.SelectedServerGroup?.SelectedServer;
                if (server == null)
                    continue;

                var resStat = _client.QueryStats("", true);
                if (resStat == null)
                    continue;

                ParseOutput(resStat, out long proxyUp, out long proxyDown, out long directUp, out long directDown);

                App.PostTask(() =>
                {
                    server.TodayUp += proxyUp;
                    server.TodayDown += proxyDown;
                    server.TotalUp += proxyUp;
                    server.TotalDown += proxyDown;

                    _config.DirectSpeedUp = directUp;
                    _config.DirectSpeedDown = directDown;
                    _config.ProxySpeedUp = proxyUp;
                    _config.ProxySpeedDown = proxyDown;
                });
            }
            catch (Exception ex)
            {
                App.PostLog(ex.Message);
            }
        }
    }

    private void ParseOutput(
        Google.Protobuf.Collections.RepeatedField<Stat> source,
        out long proxyUp,
        out long proxyDown,
        out long directUp,
        out long directDown
    )
    {
        proxyUp = 0;
        proxyDown = 0;
        directUp = 0;
        directDown = 0;
        try
        {
            foreach (Stat stat in source)
            {
                string name = stat.Name;
                long value = stat.Value;
                string[] nStr = name.Split(">>>".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                string type = "";

                name = name.Trim();

                name = nStr[1];
                type = nStr[3];

                if (name == Global.ProxyTag)
                {
                    if (type == "uplink")
                    {
                        proxyUp = value;
                    }
                    else if (type == "downlink")
                    {
                        proxyDown = value;
                    }
                }
                else if (name == Global.DirectTag)
                {
                    if (type == "uplink")
                    {
                        directUp = value;
                    }
                    else if (type == "downlink")
                    {
                        directDown = value;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            App.PostLog(ex.Message);
        }
    }
}
