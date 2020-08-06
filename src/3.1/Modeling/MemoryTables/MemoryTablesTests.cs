using Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MemoryTables
{
    public class MemoryTablesTests : BaseTest<MemoryDbContext>
    {
        public MemoryTablesTests(DbContextOptions options, bool recreate) : base(options, recreate)
        {
        }

        public void DiskTest()
        {
            var watch = new Stopwatch();
            watch.Start();

            //if (!DbContext.Blogs.Any())
            //{
                var list = new List<Blog>();
                for (int i = 0; i < 100000; i++)
                {
                    var blog = new Blog($"test blog{i}", "cui");
                    blog.SetContent($"content content content edit by {DateTime.Now.ToLongTimeString()}");

                    list.Add(blog);
                }

                DbContext.AddRange(list);
                DbContext.SaveChanges();
            //}

            Console.WriteLine($"--1-- {watch.Elapsed}");
            watch.Restart();

            var entity = DbContext.Blogs.First(o => o.Name == "test blog10");

            Console.WriteLine($"--2-- {watch.Elapsed}");
            Console.WriteLine($"{entity.Name}\r\n{entity.Content}");

            watch.Stop();
        }

        public void MemoryTest()
        {
            var watch = new Stopwatch();
            watch.Start();

            //if (!DbContext.Blogs2.Any())
            //{
                var list = new List<BlogMemory>();
                for (int i = 0; i < 100000; i++)
                {
                    var blog = new BlogMemory($"test blog{i}", "cui");
                    blog.SetContent($"content content content edit by {DateTime.Now.ToLongTimeString()}");

                    list.Add(blog);
                }

                DbContext.AddRange(list);
                DbContext.SaveChanges();
            //}

            Console.WriteLine($"--1-- {watch.Elapsed}");
            watch.Restart();

            var entity = DbContext.Blogs2.First(o => o.Name == "test blog10");

            Console.WriteLine($"--2-- {watch.Elapsed}");
            Console.WriteLine($"{entity.Name}\r\n{entity.Content}");

            watch.Stop();
        }


        public void MemoryOnlyTest()
        {
            var watch = new Stopwatch();
            watch.Start();

            //if (!DbContext.Blogs3.Any())
            //{
                var list = new List<BlogMemoryOnly>();
                for (int i = 0; i < 100000; i++)
                {
                    var blog = new BlogMemoryOnly($"test blog{i}", "cui");
                    blog.SetContent($"content content content edit by {DateTime.Now.ToLongTimeString()}");

                    list.Add(blog);
                }

                DbContext.AddRange(list);
                DbContext.SaveChanges();
            //}

            Console.WriteLine($"--1-- {watch.Elapsed}");
            watch.Restart();

            var entity = DbContext.Blogs3.First(o => o.Name == "test blog10");

            Console.WriteLine($"--2-- {watch.Elapsed}");
            Console.WriteLine($"{entity.Name}\r\n{entity.Content}");

            watch.Stop();
        }
    }
}
