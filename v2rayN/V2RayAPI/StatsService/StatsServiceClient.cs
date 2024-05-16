using Grpc.Core;

namespace v2rayN.V2RayAPI;

class StatsServiceClient
{
    private Channel channel_;
    private StatsService.StatsServiceClient client_;

    public StatsServiceClient(string target)
    {
        channel_ = new Channel(target, ChannelCredentials.Insecure);
        channel_.ConnectAsync();
        client_ = new StatsService.StatsServiceClient(channel_);
    }

    public void Shutdown()
    {
        channel_.ShutdownAsync();
    }

    public Google.Protobuf.Collections.RepeatedField<Stat> QueryStats(string pattern, bool reset)
    {
        channel_.ConnectAsync();
        if (channel_.State == ChannelState.Ready)
        {
            return client_.QueryStats(new QueryStatsRequest() { Pattern = pattern, Reset = reset }).Stat;
        }
        else
        {
            return null;
        }
    }
}
