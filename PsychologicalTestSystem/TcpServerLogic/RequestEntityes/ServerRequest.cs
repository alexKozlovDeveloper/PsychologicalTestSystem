using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpServerLogic.RequestEntityes
{
    public class ServerRequest
    {
        public RequestType Type { get; set; }

        public string TestName { get; set; }
        //public RequestType Type { get; set; }
        //public RequestType Type { get; set; }
        //public RequestType Type { get; set; }

        //public Dictionary<string, object> Params { get; set; }

        public ServerRequest()
        {
            //Params = new Dictionary<string, object>();
        }
    }
}
