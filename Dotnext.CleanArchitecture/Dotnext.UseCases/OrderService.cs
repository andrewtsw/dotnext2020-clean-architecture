using Dotnext.ApplicationServices.Interfaces;
using Dotnext.DataAccess.Interfaces;
using Dotnext.DomainServices.Interfaces;
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
        private readonly IOrdersDomainService _ordersDomainService;
        private readonly IPermissionsManager _permissionsManager;

        public OrderService(IDbContext context, 
            IOrdersIntegrationService ordersIntegrationService,
            IOrdersDomainService ordersDomainService,
            IPermissionsManager permissionsManager)
        {
            _context = context;
            _ordersIntegrationService = ordersIntegrationService;
            _ordersDomainService = ordersDomainService;
            _permissionsManager = permissionsManager;
        }

        public async Task<List<OrderDto>> GetAllAsync()
        {
            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                .ToListAsync();

            return orders
                .Select(order => new OrderDto(order)
                {
                    SubTotal = _ordersDomainService.CalculateSubTotal(order),
                    Tax = _ordersDomainService.CalculateTax(order),
                    Discount = _ordersDomainService.CalculateDiscount(order),
                    Total = _ordersDomainService.CalculateTotalPrice(order)
                })
                .ToList();
        }

        public async Task<OrderDto> GetByIdAsync(int id)
        {
            var order =  await _context.Orders
                .Include(o => o.OrderItems)
                .SingleAsync(o => o.Id == id);

            var permissions = _permissionsManager.GetCurrentUserPermissions();

            return new OrderDto(order)
            {
                SubTotal = _ordersDomainService.CalculateSubTotal(order),
                Tax = _ordersDomainService.CalculateTax(order),
                Discount = _ordersDomainService.CalculateDiscount(order),
                Total = _ordersDomainService.CalculateTotalPrice(order)
            };
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
