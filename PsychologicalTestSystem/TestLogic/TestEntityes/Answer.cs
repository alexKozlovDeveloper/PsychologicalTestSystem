using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLogic.TestEntityes
{
    [Serializable]
    public class Answer
    {
        public string Text { get; set; }
        public string ReportMessage { get; set; }
        public bool IsCheked { get; set; }

        public Answer()
        { 
            
        }
    }
}
