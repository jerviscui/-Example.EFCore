using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OwnedEntities;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var logger = LoggerFactory.Create(builder => builder.AddConsole());

            var builder = new DbContextOptionsBuilder();
            builder.UseSqlServer("Data Source=.\\sql2017;Initial Catalog=testDb;User ID=sa;Password=123456");
            builder.UseLoggerFactory(logger);

            //tests
            using var tests = new ReadonlyTests(builder.Options);
            tests.Test();

            Console.ReadLine();
        }
    }
}
