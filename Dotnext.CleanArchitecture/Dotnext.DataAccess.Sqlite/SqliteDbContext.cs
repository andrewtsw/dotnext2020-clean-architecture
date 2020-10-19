using Dotnext.DataAccess.Interfaces;
using Dotnext.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Dotnext.DataAccess.Sqlite
{
    public class SqliteDbContext : DbContext, IDbContext
    {
        public SqliteDbContext(DbContextOptions<SqliteDbContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
