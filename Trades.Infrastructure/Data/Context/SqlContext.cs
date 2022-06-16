using Microsoft.EntityFrameworkCore;
using Trades.Domain.Entitys;
using System;
using System.Linq;

namespace Trades.Infrastructure.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {
        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        public DbSet<TradeCategory> TradeCategories { get; set; }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreationDate") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreationDate").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CreationDate").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}