using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLogic.TestEntityes
{
    [Serializable]
    public class Test
    {
        public string Introduction { get; set; }
        public List<Question> Questions { get; set; }

        public Test()
        { 
        
        }

        public string GetReport()
        {
            var report = string.Empty;

            report += "Рекомендации для студента:";
            report += Environment.NewLine;

            foreach (var item in Questions)
            {
                if (item.FirstAnswer.IsCheked == true)
                {
                    report += item.FirstAnswer.ReportMessage;
                }

                if (item.SecondAnswer.IsCheked == true)
                {
                    report += item.SecondAnswer.ReportMessage;
                }

                if (item.ThirdAnswer.IsCheked == true)
                {
                    report += item.ThirdAnswer.ReportMessage;
                }

                report += Environment.NewLine;
            }

            return report;
        }
    }
}
