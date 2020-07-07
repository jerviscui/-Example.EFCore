using Common;
using Microsoft.EntityFrameworkCore;
using ReadonlyProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OwnedEntities
{
    public class ReadonlyTests : BaseTest<ReadonlyDbContext>
    {
        public ReadonlyTests(DbContextOptions options) : base(options)
        {
        }

        public void Test()
        {
            if (!DbContext.Blogs.Any())
            {
                var blog = new Blog("test blog", "cui");

                blog.SetContent($"content content content edit by {DateTime.Now.ToLongTimeString()}");

                DbContext.Blogs.Add(blog);
                DbContext.SaveChanges();
            }

            var entity = DbContext.Blogs.First();

            Console.WriteLine($"{entity.Name}\r\n{entity.Content}");
        }
    }
}
