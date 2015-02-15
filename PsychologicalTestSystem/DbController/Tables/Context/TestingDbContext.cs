using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbController.Tables.Context
{
    class TestingDbContext : DbContext 
    {
        public DbSet<QuestionT> Questions { get; set; }
        public DbSet<UserT> Users { get; set; }
        public DbSet<TestingT> Testing { get; set; } 
    }
}
