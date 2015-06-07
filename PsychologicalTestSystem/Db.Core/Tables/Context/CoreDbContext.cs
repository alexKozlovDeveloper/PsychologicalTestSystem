using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db.Core.Tables.Context
{
    class CoreDbContextV8 : DbContext
    {
        public DbSet<AvailableTestToGroupT> AvailableTestToGroup { get; set; }
        public DbSet<GroupT> Groups { get; set; }
        public DbSet<PassingTestT> PassingsTest { get; set; }
        public DbSet<QuestionT> Questions { get; set; }
        public DbSet<QuestionToTestT> QuestionsToTests { get; set; }
        public DbSet<TestingT> Testing { get; set; }
        public DbSet<TestT> Tests { get; set; }
        public DbSet<UserT> Users { get; set; }
    }
}
