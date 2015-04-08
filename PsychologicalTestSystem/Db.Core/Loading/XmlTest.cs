using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db.Core.TableEntityes;

namespace Db.Core.Loading
{
    public class XmlTest
    {
        public class AvailableGroup
        {
            public Group GroupInfo { get; set; }
            public bool IsAvailable { get; set; }

            public AvailableGroup()
            {

            }
        }

        public Test TestInfo { get; set; }
        public List<Question> Questions { get; set; }
        public List<AvailableGroup> AvailableGroups { get; set; }

        public XmlTest()
        {
            Questions = new List<Question>();
            AvailableGroups = new List<AvailableGroup>();
        }
    }
}
