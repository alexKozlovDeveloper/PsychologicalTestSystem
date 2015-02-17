using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpClientServerLogic.Server
{
    class TcpServer
    {
        private Socket _sListener;
        private const int DefaultPort = 11993;
        private const int ClientMaxCount = 45;

        public TcpServer()
        {

        }

        public void Start(int port = DefaultPort)
        {
            var hostName = Dns.GetHostName();
            var ipHost = Dns.GetHostEntry(hostName);
            var ipAddr = ipHost.AddressList[0];
            var ipEndPoint = new IPEndPoint(ipAddr, port);

            _sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                _sListener.Bind(ipEndPoint);
                _sListener.Listen(ClientMaxCount);

                while (true)
                {
                    var handler = _sListener.Accept();
                    string data = null;

                    var bytes = new byte[1024];
                    var bytesRec = handler.Receive(bytes);

                    data += Encoding.UTF8.GetString(bytes, 0, bytesRec);

                    Console.Write("Полученный текст: " + data + "\n\n");

                    var reply = "Спасибо за запрос в " + data.Length + " символов";
                    var msg = Encoding.UTF8.GetBytes(reply);
                    handler.Send(msg);

                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadLine();
            }

        }
    }
}
