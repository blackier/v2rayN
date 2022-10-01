using Shadowsocks.Model;
using Shadowsocks.Model.Transfer;
using Shadowsocks.Proxy;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Shadowsocks.Controller.Service
{
    public class Local : Listener.Service
    {
        private readonly Configuration _config;
        private readonly ServerTransferTotal _transfer;

        public Local(Configuration config, ServerTransferTotal transfer)
        {
            _config = config;
            _transfer = transfer;
        }

        private static bool Accept(byte[] firstPacket, int length)
        {
            if (length < 2)
            {
                return false;
            }
            if (firstPacket[0] is 5 or 4)
            {
                return true;
            }
            Debug.WriteLine(System.Text.Encoding.UTF8.GetString(firstPacket));
            if (length > 8
                && firstPacket[0] == 'C'
                && firstPacket[1] == 'O'
                && firstPacket[2] == 'N'
                && firstPacket[3] == 'N'
                && firstPacket[4] == 'E'
                && firstPacket[5] == 'C'
                && firstPacket[6] == 'T'
                && firstPacket[7] == ' ')
            {
                return true;
            }
            return false;
        }

        public override bool Handle(byte[] firstPacket, int length, Socket socket)
        {
            if (!_config.PortMapCache.ContainsKey(((IPEndPoint)socket.LocalEndPoint).Port) && !Accept(firstPacket, length))
            {
                return false;
            }
            Task.Run(() =>
            {
                var unused = new ProxyAuthHandler(_config, _transfer, firstPacket, length, socket);
            });
            return true;
        }
    }
}
