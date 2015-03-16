using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbController.Repositoryes;

namespace TcpServerLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new TestTcpServer(new TestingRepository());
            server.Start();
        }
    }
}
