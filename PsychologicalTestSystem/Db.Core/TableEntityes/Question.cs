using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db.Core.TableEntityes
{
    public class Question
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string FirstAnswer { get; set; }
        public string SecondAnswer { get; set; }
        public string ThirdAnswer { get; set; }
        public string FirstReportMessage { get; set; }
        public string SecondReportMessage { get; set; }
        public string ThirdReportMessage { get; set; }
    }
}
