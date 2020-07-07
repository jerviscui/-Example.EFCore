using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace OwnedEntities
{
    public class OwnedDbContext : BaseDbContext
    {
        public OwnedDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().OwnsOne(o => o.ShippingAddress);
            //私有属性使用名称关联
            //modelBuilder.Entity<Order>().OwnsOne<StreetAddress>("ShippingAddress2");

            modelBuilder.Entity<Distributor>().OwnsMany(o => o.ShippingCenters/*,
                builder =>
                {
                    builder.WithOwner().HasForeignKey("DistributorId");
                    builder.Property<int>("Id");
                    builder.HasKey("Id");
                }*/);
        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Distributor> Distributors { get; set; }
    }
}
