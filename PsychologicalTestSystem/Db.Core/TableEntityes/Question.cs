using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db.Core.TableEntityes
{
    public class Question : IComparable
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

        public int SortIndex { get; set; }

        public override string ToString()
        {
            if (Message.Length < 20)
            {
                return Message;
            }

            var res = "";

            for (var i = 0; i < 20; i++)
            {
                res += Message[i];
            }

            res += "...";

            return res;
        }
        
        public int CompareTo(object obj)
        {
            Question q = obj as Question;

            var res =  this.SortIndex.CompareTo(q.SortIndex);

            return res;
        }
    }
}
