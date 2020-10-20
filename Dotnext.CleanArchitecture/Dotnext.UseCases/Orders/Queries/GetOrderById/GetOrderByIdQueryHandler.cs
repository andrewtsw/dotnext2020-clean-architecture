using Dotnext.ApplicationServices.Interfaces;
using Dotnext.DataAccess.Interfaces;
using Dotnext.DomainServices.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Dotnext.UseCases.Orders.Queries.GetOrderById
{
    internal class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly IDbContext _context;
        private readonly IOrdersDomainService _ordersDomainService;
        private readonly IPermissionsManager _permissionsManager;

        public GetOrderByIdQueryHandler(IDbContext context,
            IOrdersDomainService ordersDomainService,
            IPermissionsManager permissionsManager)
        {
            _context = context;
            _ordersDomainService = ordersDomainService;
            _permissionsManager = permissionsManager;
        }

        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .SingleAsync(o => o.Id == request.OrderId);

            var permissions = _permissionsManager.GetCurrentUserPermissions();

            return new OrderDto(order)
            {
                SubTotal = _ordersDomainService.CalculateSubTotal(order),
                Tax = _ordersDomainService.CalculateTax(order),
                Discount = _ordersDomainService.CalculateDiscount(order),
                Total = _ordersDomainService.CalculateTotalPrice(order)
            };
        }
    }
}
