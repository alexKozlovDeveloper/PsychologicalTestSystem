using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DbController.Repositoryes;

namespace TcpServerLogic
{
    public class RequestProcessor
    {
        private readonly Socket _handler;
        private TestTcpServer _server;
        private Thread _executeThread;

        public bool IsCompleted { get; set; }

        public RequestProcessor(Socket handler, TestTcpServer server)
        {
            _handler = handler;
            _server = server;
            IsCompleted = false;
        }

        public void StartExecute()
        {
            _executeThread = new Thread(Execution);
            _executeThread.Start();
        }

        public void Execution()
        {
            string data = null;

            var bytes = new byte[1024];
            var bytesRec = _handler.Receive(bytes);

            data += Encoding.UTF8.GetString(bytes, 0, bytesRec);


            


            //Console.Write("Полученный текст: " + data + "\n\n");

            var reply = "Спасибо за запрос в " + data.Length + " символов";
            var msg = Encoding.UTF8.GetBytes(reply);
            _handler.Send(msg);


            ///////

            _handler.Shutdown(SocketShutdown.Both);
            _handler.Close();

            IsCompleted = true;
        }
    }
}
