using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbController.Tables
{
    class QuestionToTestT
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public Guid TestId { get; set; }
    }
}
