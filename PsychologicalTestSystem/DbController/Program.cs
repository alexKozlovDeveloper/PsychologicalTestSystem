using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbController.Tables;
using DbController.Tables.Context;

namespace DbController
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var db = new TestingDbContext())
            {
                //UserT user = new UserT() { FirstName = "Alex", LastName = "dog", Id = Guid.NewGuid(), GroupNumber = "136660" };

                //db.Users.Add(user);
                //db.SaveChanges();

                foreach (var item in db.Users)
                {
                    Console.WriteLine("id [{0}] FN [{1}] LN [{2}] GN [{3}]", item.Id, item.FirstName, item.LastName, item.GroupNumber);
                }

                //// Create and save a new Blog 
                //Console.Write("Enter a name for a new Blog: ");
                //var name = Console.ReadLine();

                //var blog = new Blog { Name = name };
                //db.Blogs.Add(blog);
                //db.SaveChanges();

                //// Display all Blogs from the database 
                //var query = from b in db.Blogs
                //            orderby b.Name
                //            select b;

                //Console.WriteLine("All blogs in the database:");
                //foreach (var item in query)
                //{
                //    Console.WriteLine(item.Name);
                //}



                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            } 
        }
    }
}
