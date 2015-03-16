using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpClienLogic
{
    public class TestTcpClient
    {
        private const int DefaultPort = 11993;

        private IPHostEntry _ipHost;
        private IPAddress _ipAddr;
        private IPEndPoint _ipEndPoint;
        private Socket _sender;

        public TestTcpClient()
        {

        }

        public bool ConnectToServer(string serverIpAddress, int port)
        {
            _ipHost = Dns.GetHostEntry("localhost");
            _ipAddr = _ipHost.AddressList[0];
            _ipEndPoint = new IPEndPoint(_ipAddr, port);

            _sender = new Socket(_ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                _sender.Connect(_ipEndPoint);
            }
            catch (Exception ex)
            {
                _ipHost = null;
                _ipAddr = null;
                _ipEndPoint = null;
                _sender = null;
                return false;
            }

            return true;
        }

        public string SendMessage(string message)
        {
            var bytes = new byte[1024];

            var msg = Encoding.UTF8.GetBytes(message);

            var bytesSent = _sender.Send(msg);

            var bytesRec = _sender.Receive(bytes);

            return Encoding.UTF8.GetString(bytes, 0, bytesRec);
        }

        public bool IsConnect
        {
            get { return _sender != null; }
        }
    }
}
