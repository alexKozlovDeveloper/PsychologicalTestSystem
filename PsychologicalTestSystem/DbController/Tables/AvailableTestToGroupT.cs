using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbController.Tables
{
    class AvailableTestToGroupT
    {
        public Guid Id { get; set; }
        public Guid GroupId { get; set; }
        public Guid TestId { get; set; }
    }
}
