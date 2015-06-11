using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopAdministrator.DataGridEntityes
{
    class TestingUser : IComparable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GroupNumber { get; set; }
        public DateTime Date { get; set; }
        public Guid PassingTestId { get; set; }
        public string TestName { get; set; }

        public int CompareTo(object obj)
        {
            var item = obj as TestingUser;

            return this.Date.CompareTo(item.Date);
        }
    }
}
