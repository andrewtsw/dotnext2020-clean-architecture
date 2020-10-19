using Dotnext.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Dotnext.DataAccess.Interfaces
{
    public interface IDbContext
    {
        DbSet<Order> Orders { get; }

        DbSet<OrderItem> OrderItems { get; }

        DbSet<Product> Products { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
