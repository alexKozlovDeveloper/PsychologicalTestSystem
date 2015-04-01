using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db.Core.TableEntityes
{
    public class Group
    {
        public Guid Id { get; set; }
        public string Number { get; set; }

        public override string ToString()
        {
            return Number;
        }
    }
}
