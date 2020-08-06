using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadonlyProperties
{
    public class ReadonlyDbContext : BaseDbContext
    {
        public ReadonlyDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>();
        }

        public DbSet<Blog> Blogs { get; set; }
    }
}
