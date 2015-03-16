using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpClienLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new TestTcpClient();
            client.ConnectToServer("10.19.1.1", 11993);

            while (true)
            {
                client.SendMessage("lol");
            }
        }
    }
}
