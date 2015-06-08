using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db.Core.TableEntityes
{
    public class PassingTest : IComparable
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid TestId { get; set; }
        public DateTime Date { get; set; }

        public int CompareTo(object obj)
        {
            var item = obj as PassingTest;

            return Date.CompareTo(item.Date);
        }
    }
}
