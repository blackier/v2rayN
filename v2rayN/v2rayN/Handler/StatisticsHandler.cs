using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using v2rayN.Mode;
using v2rayN.V2RayAPI;

namespace v2rayN.Handler
{
    class StatisticsHandler
    {
        private Mode.Config config_;
        private ServerStatistics serverStatistics_;
        private StatsServiceClient client_;
        private bool exitFlag_;
        private Task loopTask_;

        Action<ulong, ulong, List<ServerStatItem>> updateFunc_;

        public bool Enable
        {
            get; set;
        }

        public bool UpdateUI
        {
            get; set;
        }

        public List<ServerStatItem> Statistic => serverStatistics_.server;

        public StatisticsHandler(Mode.Config config, Action<ulong, ulong, List<ServerStatItem>> update)
        {
            config_ = config;
            Enable = config.enableStatistics;
            UpdateUI = false;
            updateFunc_ = update;
            exitFlag_ = false;

            client_ = new StatsServiceClient($"{Global.Loopback}:{Global.v2rayApiPort}");

            LoadFromFile();

            loopTask_ = new Task(() => Run());
            loopTask_.Start();
        }

        public void Close()
        {
            try
            {
                exitFlag_ = true;
                if (loopTask_.Status == TaskStatus.Running)
                {
                    loopTask_.Wait();
                }                
                client_.Shutdown();
            }
            catch (Exception ex)
            {
                Utils.SaveLog(ex.Message, ex);
            }
        }

        public void Run()
        {
            while (!exitFlag_)
            {
                try
                {
                    var resStat = client_.QueryStats("", true);
                    if (resStat != null)
                    {
                        string itemId = config_.getItemId();
                        ServerStatItem serverStatItem = GetServerStatItem(itemId);

                        ParseOutput(resStat, out ulong up, out ulong down);

                        serverStatItem.todayUp += up;
                        serverStatItem.todayDown += down;
                        serverStatItem.totalUp += up;
                        serverStatItem.totalDown += down;

                        if (UpdateUI)
                        {
                            updateFunc_(up, down, new List<ServerStatItem> { serverStatItem });
                        }
                    }
                    Thread.Sleep(config_.statisticsFreshRate);
                }
                catch (Exception ex)
                {
                    Utils.SaveLog(ex.Message, ex);
                }
            }
        }

        public void LoadFromFile()
        {
            try
            {
                string result = Utils.LoadResource(Utils.GetPath(Global.StatisticLogOverall));
                if (!Utils.IsNullOrEmpty(result))
                {
                    //转成Json
                    serverStatistics_ = Utils.FromJson<ServerStatistics>(result);
                }

                if (serverStatistics_ == null)
                {
                    serverStatistics_ = new ServerStatistics();
                }
                if (serverStatistics_.server == null)
                {
                    serverStatistics_.server = new List<ServerStatItem>();
                }

                long ticks = DateTime.Now.Date.Ticks;
                foreach (ServerStatItem item in serverStatistics_.server)
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
                Utils.SaveLog(ex.Message, ex);
            }
        }

        public void SaveToFile()
        {
            try
            {
                Utils.ToJsonFile(serverStatistics_, Utils.GetPath(Global.StatisticLogOverall));
            }
            catch (Exception ex)
            {
                Utils.SaveLog(ex.Message, ex);
            }
        }

        private ServerStatItem GetServerStatItem(string itemId)
        {
            long ticks = DateTime.Now.Date.Ticks;
            int cur = Statistic.FindIndex(item => item.itemId == itemId);
            if (cur < 0)
            {
                Statistic.Add(new ServerStatItem
                {
                    itemId = itemId,
                    totalUp = 0,
                    totalDown = 0,
                    todayUp = 0,
                    todayDown = 0,
                    dateNow = ticks
                });
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

            up = 0; down = 0;
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
                Utils.SaveLog(ex.Message, ex);
            }
        }

    }
}
