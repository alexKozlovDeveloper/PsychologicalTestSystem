using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db.Core.TableEntityes;
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
                GroupId = Guid.NewGuid(),
                Id = Guid.NewGuid()
            };


            var xml = XmlSerializerHelper.SerializeToString(f);

            var g = XmlSerializerHelper.DeserializeFromString<User>(xml);
        }
    }
}
