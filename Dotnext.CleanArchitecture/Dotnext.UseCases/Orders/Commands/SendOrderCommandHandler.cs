using Dotnext.DataAccess.Interfaces;
using Dotnext.Integration.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Dotnext.UseCases.Orders.Commands
{
    internal class SendOrderCommandHandler : IRequestHandler<SendOrderCommand, OrderDto>
    {
        private readonly IDbContext _context;
        private readonly IOrdersIntegrationService _ordersIntegrationService;

        public SendOrderCommandHandler(IDbContext context,
            IOrdersIntegrationService ordersIntegrationService)
        {
            _context = context;
            _ordersIntegrationService = ordersIntegrationService;
        }

        public async Task<OrderDto> Handle(SendOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .SingleAsync(o => o.Id == request.OrderId);

            var externalId = await _ordersIntegrationService.SendOrderAsync(order);
            order.ExternalId = externalId;
            await _context.SaveChangesAsync();

            return new OrderDto(order);
        }
    }
}
