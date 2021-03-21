using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace AIStudio.Wpf.DataRepository
{
    public class BaseDbContext : DbContext
    {

        public BaseDbContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public void Detach()
        {
            ChangeTracker.Entries().ToList().ForEach(aEntry =>
            {
                if (aEntry.State != EntityState.Detached)
                    aEntry.State = EntityState.Detached;
            });
        }

    }
}
