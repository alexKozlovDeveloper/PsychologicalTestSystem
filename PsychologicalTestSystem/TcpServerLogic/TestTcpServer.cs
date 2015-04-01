using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DbController.Repositoryes;

namespace TcpServerLogic
{
    public class TestTcpServer
    {
        //private Socket _sListener;
        private const int DefaultPort = 11993;
        private const int ClientMaxCount = 300;

        private Thread _serverThread;
        private List<RequestProcessor> _processors;
        private List<RequestProcessor> _toRemoveProcessors; 

        private Socket _listener;
        private IPEndPoint _ipEndPoint;

        private ITestingRepository _repository;

        public ITestingRepository Repository 
        {
            get { return _repository; }
        }

        public List<RequestProcessor> Processors
        {
            get { return _processors; }
        }

        public List<RequestProcessor> ToRemoveProcessors
        {
            get { return _toRemoveProcessors; }
        }

        public TestTcpServer()
        {
            _repository = new TestingRepository();
        }

        public TestTcpServer(ITestingRepository repository)
        {
            _repository = repository;
        }

        public void Start(int port = DefaultPort)
        {
            var hostIpAddres = GetHostIpv4Address();
            _ipEndPoint = new IPEndPoint(hostIpAddres, port);
            _listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            _serverThread = new Thread(RequestListener);

            _processors = new List<RequestProcessor>();
            _toRemoveProcessors = new List<RequestProcessor>();

            _serverThread.Start();
        }

        public void Stop()
        {
            if (_serverThread != null)
            {
                _serverThread.Abort();
            }
        }

        public void RequestListener()
        {
            try
            {
                _listener.Bind(_ipEndPoint);
                _listener.Listen(ClientMaxCount);

                while (true)
                {
                    var handler = _listener.Accept();

                    var rp = new RequestProcessor(handler, this);

                    _processors.Add(rp);

                    rp.StartExecute();
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

        //public void ExecuteRequest()
        //{
        //    string data = null;

        //    var bytes = new byte[1024];
        //    var bytesRec = handler.Receive(bytes);

        //    data += Encoding.UTF8.GetString(bytes, 0, bytesRec);

        //    Console.Write("Полученный текст: " + data + "\n\n");

        //    var reply = "Спасибо за запрос в " + data.Length + " символов";
        //    var msg = Encoding.UTF8.GetBytes(reply);
        //    handler.Send(msg);

        //    handler.Shutdown(SocketShutdown.Both);
        //    handler.Close();
        //}

        private IPAddress GetHostIpv4Address()
        {
            var hostName = Dns.GetHostName();
            var ipHost = Dns.GetHostEntry(hostName);
            IPAddress ipAddr = null;

            foreach (var hostAddr in ipHost.AddressList)
            {
                if (hostAddr.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipAddr = hostAddr;
                    break;
                }
            }

            return ipAddr;
        }
    }
}
