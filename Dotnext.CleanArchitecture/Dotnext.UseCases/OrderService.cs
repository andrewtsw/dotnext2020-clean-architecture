using Dotnext.DataAccess.Sqlite;
using Dotnext.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnext.UseCases
{
    internal class OrderService : IOrderService
    {
        private readonly SqliteDbContext _context;

        public OrderService(SqliteDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrderDto>> GetAllAsync()
        {
            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                .ToListAsync();

            return orders
                .Select(o => new OrderDto(o))
                .ToList();
        }

        public async Task<OrderDto> GetByIdAsync(int id)
        {
            var order =  await _context.Orders
                .Include(o => o.OrderItems)
                .SingleAsync(o => o.Id == id);

            return new OrderDto(order);
        }
    }
}
