using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopAdministrator.DataGridEntityes
{
    class AvailableGroups
    {
        public string GroupName { get; set; }
        public bool IsAvailable { get; set; }

        public Guid TestId { get; set; }
        public Guid GroupId { get; set; }
    }
}
