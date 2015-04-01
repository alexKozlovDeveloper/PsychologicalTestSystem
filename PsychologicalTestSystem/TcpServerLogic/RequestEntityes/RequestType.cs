using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpServerLogic.RequestEntityes
{
    public enum RequestType
    {
        GetAllGroup = 1,
        GetStudents,
        GetTest,
        AddTestResult
    }
}
