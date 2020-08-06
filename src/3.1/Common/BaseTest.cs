using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public abstract class BaseTest<TDbContext> : IDisposable
        where TDbContext : BaseDbContext
    {
        public TDbContext DbContext { get; private set; }

        protected BaseTest(DbContextOptions options, bool recreate = true)
        {
            DbContext = (TDbContext)Activator.CreateInstance(typeof(TDbContext), options);

            if (recreate)
            {
                DbContext.Database.EnsureDeleted();
                DbContext.Database.EnsureCreated();
            }
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
