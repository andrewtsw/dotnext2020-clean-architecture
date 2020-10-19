using Dotnext.DataAccess.Interfaces;
using Dotnext.Integration.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnext.UseCases
{
    internal class OrderService : IOrderService
    {
        private readonly IDbContext _context;
        private readonly IOrdersIntegrationService _ordersIntegrationService;

        public OrderService(IDbContext context, IOrdersIntegrationService ordersIntegrationService)
        {
            _context = context;
            _ordersIntegrationService = ordersIntegrationService;
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

        public async Task<OrderDto> SendAsync(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .SingleAsync(o => o.Id == id);

            var externalId = await _ordersIntegrationService.SendOrderAsync(order);
            order.ExternalId = externalId;
            await _context.SaveChangesAsync();

            return new OrderDto(order);
        }
    }
}
