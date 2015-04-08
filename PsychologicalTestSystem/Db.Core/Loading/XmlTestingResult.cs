using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db.Core.TableEntityes;

namespace Db.Core.Loading
{
    public class XmlTestingResult
    {
        public class TestingResult
        {
            public Guid QuestionId { get; set; }
            public int ChekedAnswer { get; set; }
        }

        public User UserInfo { get; set; }
        public DateTime Date { get; set; }
        public Guid TestId { get; set; }

        public List<TestingResult> TestingResults { get; set; }

        public XmlTestingResult()
        {
            TestingResults = new List<TestingResult>();
        }
    }
}
