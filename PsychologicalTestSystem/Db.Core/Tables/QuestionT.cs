using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db.Core.Tables
{
    class QuestionT
    {
        public Guid Id { get; set; }

        public string Message { get; set; }

        public string FirstAnswer { get; set; }
        public string SecondAnswer { get; set; }
        public string ThirdAnswer { get; set; }

        public string FirstReportMessageToUser { get; set; }
        public string SecondReportMessageToUser { get; set; }

        public string FirstReportMessageToAdmin { get; set; }
        public string SecondReportMessageToAdmin { get; set; }

        public int StrongProblemNumber { get; set; }
        public int WeakProblemNumber { get; set; }
    }
}
