using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbController.Tables.Context
{
    class TestingDbContext2 : DbContext 
    {
        public DbSet<QuestionT> Questions { get; set; }
        public DbSet<UserT> Users { get; set; }
        public DbSet<TestingT> Testing { get; set; }
        public DbSet<GroupT> Groups { get; set; }
        public DbSet<TestT> Tests { get; set; } 
    }
}
