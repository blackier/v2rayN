using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using v2rayN.Config;
using v2rayN.V2RayAPI;

namespace v2rayN.Handlers;

class StatisticsHandler
{
    private V2RayNConfig _config;
    private ServerStatistics _serverStatistics;
    private StatsServiceClient _client;
    private bool _exitFlag;
    private Task _loopTask;

    private Action<ulong, ulong, List<ServerStatItem>> _updateFunc;

    public bool Enable { get; set; }

    public bool UpdateUI { get; set; }

    public List<ServerStatItem> Statistic => _serverStatistics.server;

    public StatisticsHandler(V2RayNConfig config, Action<ulong, ulong, List<ServerStatItem>> update)
    {
        _config = config;
        _updateFunc = update;
        _exitFlag = false;
        _client = new StatsServiceClient($"{Global.Loopback}:{Global.v2rayApiPort}");

        Enable = config.enableStatistics;
        UpdateUI = false;

        LoadFromFile();

        _loopTask = new Task(() => Run());
        _loopTask.Start();
    }

    public void Close()
    {
        try
        {
            _exitFlag = true;
            if (_loopTask.Status == TaskStatus.Running)
            {
                _loopTask.Wait();
            }
            _client.Shutdown();
        }
        catch (Exception ex)
        {
            Log.SaveLog(ex.Message, ex);
        }
    }

    public void Run()
    {
        while (!_exitFlag)
        {
            try
            {
                var resStat = _client.QueryStats("", true);
                if (resStat != null)
                {
                    string itemId = _config.getItemId();
                    ServerStatItem serverStatItem = GetServerStatItem(itemId);

                    ParseOutput(resStat, out ulong up, out ulong down);

                    serverStatItem.todayUp += up;
                    serverStatItem.todayDown += down;
                    serverStatItem.totalUp += up;
                    serverStatItem.totalDown += down;

                    if (UpdateUI)
                    {
                        _updateFunc(up, down, new List<ServerStatItem> { serverStatItem });
                    }
                }
                Thread.Sleep(_config.statisticsFreshRate);
            }
            catch (Exception ex)
            {
                Log.SaveLog(ex.Message, ex);
            }
        }
    }

    public void LoadFromFile()
    {
        try
        {
            string result = Misc.LoadResource(Misc.GetPath(Global.StatisticLogOverall));
            if (!Misc.IsNullOrEmpty(result))
            {
                //转成Json
                _serverStatistics = Json.FromJson<ServerStatistics>(result);
            }

            if (_serverStatistics == null)
            {
                _serverStatistics = new ServerStatistics();
            }
            if (_serverStatistics.server == null)
            {
                _serverStatistics.server = new List<ServerStatItem>();
            }

            long ticks = DateTime.Now.Date.Ticks;
            foreach (ServerStatItem item in _serverStatistics.server)
            {
                if (item.dateNow != ticks)
                {
                    item.todayUp = 0;
                    item.todayDown = 0;
                    item.dateNow = ticks;
                }
            }
        }
        catch (Exception ex)
        {
            Log.SaveLog(ex.Message, ex);
        }
    }

    public void SaveToFile()
    {
        try
        {
            Json.ToJsonFile(_serverStatistics, Misc.GetPath(Global.StatisticLogOverall));
        }
        catch (Exception ex)
        {
            Log.SaveLog(ex.Message, ex);
        }
    }

    private ServerStatItem GetServerStatItem(string itemId)
    {
        long ticks = DateTime.Now.Date.Ticks;
        int cur = Statistic.FindIndex(item => item.itemId == itemId);
        if (cur < 0)
        {
            Statistic.Add(
                new ServerStatItem
                {
                    itemId = itemId,
                    totalUp = 0,
                    totalDown = 0,
                    todayUp = 0,
                    todayDown = 0,
                    dateNow = ticks
                }
            );
            cur = Statistic.Count - 1;
        }
        if (Statistic[cur].dateNow != ticks)
        {
            Statistic[cur].todayUp = 0;
            Statistic[cur].todayDown = 0;
            Statistic[cur].dateNow = ticks;
        }
        return Statistic[cur];
    }

    private void ParseOutput(Google.Protobuf.Collections.RepeatedField<Stat> source, out ulong up, out ulong down)
    {
        up = 0;
        down = 0;
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

                if (name == Global.agentTag)
                {
                    if (type == "uplink")
                    {
                        up = (ulong)value;
                    }
                    else if (type == "downlink")
                    {
                        down = (ulong)value;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Log.SaveLog(ex.Message, ex);
        }
    }
}
