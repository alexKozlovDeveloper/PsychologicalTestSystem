using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db.Core.Tables;
using Db.Core.Tables.Context;

namespace Db.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new CoreDbContextV4())
            {
                var g = new GroupT
                {
                    Id = Guid.NewGuid(),
                    Number = "030303"
                };

                db.Groups.Add(g);
                db.SaveChanges();

                foreach (var t in db.Groups)
                {
                    Console.WriteLine(t.Number);
                }

                //var group = new GroupT() {Id = Guid.NewGuid(), Number = "010902" };
                //var user = new UserT() { FirstName = "Alex", LastName = "dog", Id = Guid.NewGuid(), GroupId = group.Id };

                //db.Groups.Add(group);
                //db.Users.Add(user);
                //db.SaveChanges();

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            } 
        }
    }
}
