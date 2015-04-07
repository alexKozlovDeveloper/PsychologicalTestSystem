using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db.Core.Tables
{
    class TestingT
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public int ChekedAnswer { get; set; }
        public Guid PassingTestId { get; set; }
    }
}
