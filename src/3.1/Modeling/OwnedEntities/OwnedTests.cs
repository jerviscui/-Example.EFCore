using Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OwnedEntities
{
    public class OwnedTests : BaseTest<OwnedDbContext>
    {
        public OwnedTests(DbContextOptions options) : base(options)
        {
        }

        public void OwnsOneTest()
        {
            if (!DbContext.Orders.Any())
            {
                var order1 = new Order()
                {
                    ShippingAddress = new StreetAddress()
                    {
                        City = "SZ",
                        Street = "nanshan",
                    }
                };

                var order2 = new Order()
                {
                    ShippingAddress = new StreetAddress()
                    {
                        City = "SZ",
                        Street = "baoan",
                    }
                };

                DbContext.Orders.AddRange(order1, order2);

                DbContext.SaveChanges();
            }

            var list = DbContext.Orders.ToList();

            var order = DbContext.Orders.FirstOrDefault(o => o.ShippingAddress.Street == "baoan");
        }

        public void OwnsManyTest()
        {
            if (!DbContext.Distributors.Any())
            {
                var distributor = new Distributor()
                {
                    ShippingCenters = new List<StreetAddress>()
                    {
                        new StreetAddress()
                        {
                            City = "SZ",
                            Street = "nanshan",
                        },
                        new StreetAddress()
                        {
                            City = "SZ",
                            Street = "baoan",
                        }
                    }
                };

                DbContext.Distributors.Add(distributor);

                DbContext.SaveChanges();
            }

            var list = DbContext.Distributors.ToList();

            var entity = DbContext.Distributors.FirstOrDefault(o => o.ShippingCenters.Any(addr => addr.Street == "baoan"));
        }
    }
}
