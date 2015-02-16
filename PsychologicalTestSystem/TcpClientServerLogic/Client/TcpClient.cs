using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpClientServerLogic.Client
{
    class TcpClient
    {
        private IPHostEntry _ipHost;
        private IPAddress _ipAddr;
        private IPEndPoint _ipEndPoint;
        private Socket _sender;

        public TcpClient()
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
            catch (Exception)
            {
                _ipHost = null;
                _ipAddr = null;
                _ipEndPoint = null;
                _sender = null;
                return false;
            }

            return true;
        }

        public void SendMessage()
        {

        }

        public bool IsConnect
        {
            get { return _sender != null; }
        }
    }
}
