using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbController.Repositoryes;
using DbController.TableEntityes;
using TcpServerLogic.Convert;

namespace TcpServerLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            //var server = new TestTcpServer(new TestingRepository());
            //server.Start();



            var f = new User
            {
                FirstName = "FirstName", 
                LastName = "LastName",
                GroupNumber = Guid.NewGuid(),
                Id = Guid.NewGuid()
            };


            var xml = XmlSerializerHelper.SerializeToString(f);

            var g = XmlSerializerHelper.DeserializeFromString<User>(xml);
        }
    }
}
