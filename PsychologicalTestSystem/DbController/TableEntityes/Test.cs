using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbController.TableEntityes
{
    public class Test
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<Question> Questions { get; set; }
    }
}
