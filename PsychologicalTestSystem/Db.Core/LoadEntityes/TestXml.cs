using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db.Core.Repositoryes;
using Db.Core.TableEntityes;

namespace Db.Core.LoadEntityes
{
    class TestXml
    {
        public string Name { get; set; }
        public Guid Id { get; set; }

        public List<Question> Questions { get; set; }

        public TestXml()
        {
            //Questions = new List<Question>();
        }
    }
}
