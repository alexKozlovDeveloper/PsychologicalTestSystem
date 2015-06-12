using Db.Core.TableEntityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopAdministrator.DataGridEntityes
{
    class PassingTestInfo
    {
        public Guid PassingTestId { get; set; }
        public DateTime Date { get; set; }
        public string TestName { get; set; }
        public User User { get; set; }

        public override string ToString()
        {
            return string.Format("Тест: {0}{1} Дата: {2}{3} Студент: {4} {5}", TestName, Environment.NewLine, Date.ToString(), Environment.NewLine, User.FirstName, User.LastName);
        }
    }
}
