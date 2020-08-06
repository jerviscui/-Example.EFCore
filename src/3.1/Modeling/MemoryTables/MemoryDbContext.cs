using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryTables
{
    public class MemoryDbContext : BaseDbContext
    {
        public MemoryDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().HasIndex(o => o.Name);

            modelBuilder.Entity<BlogMemory>().HasIndex(o => o.Name);
            modelBuilder.Entity<BlogMemory>().IsMemoryOptimized();
            
            modelBuilder.Entity<BlogMemoryOnly>().IsMemoryOptimized();
            //Blogs3 使用sql建表
///****** Object:  Table [dbo].[Blogs3]    Script Date: 2020-07-10 10:31:15 ******/
//SET ANSI_NULLS ON
//GO

//SET QUOTED_IDENTIFIER ON
//GO

//CREATE TABLE [dbo].[Blogs3]
//(
//	[Id] [int] IDENTITY(1,1) NOT NULL,
//	[Name] [nvarchar](450) COLLATE Chinese_PRC_CI_AS NULL,
//	[Author] [nvarchar](max) COLLATE Chinese_PRC_CI_AS NULL,
//	[Content] [nvarchar](max) COLLATE Chinese_PRC_CI_AS NULL,

//INDEX [IX_Blogs3_Name] NONCLUSTERED 
//(
//	[Name] ASC
//),
// CONSTRAINT [PK_Blogs3]  PRIMARY KEY NONCLUSTERED 
//(
//	[Id] ASC
//)
//)WITH ( MEMORY_OPTIMIZED = ON , DURABILITY = SCHEMA_ONLY )
//GO            
        }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<BlogMemory> Blogs2 { get; set; }

        public DbSet<BlogMemoryOnly> Blogs3 { get; set; }
    }
}
