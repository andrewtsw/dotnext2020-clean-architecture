using Dotnext.DataAccess.Interfaces;
using Dotnext.DomainServices.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dotnext.UseCases.Orders.Queries.GetAllOrders
{
    internal class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, List<OrderDto>>
    {
        private readonly IDbContext _context;
        private readonly IOrdersDomainService _ordersDomainService;

        public GetAllOrdersQueryHandler(IDbContext context,
            IOrdersDomainService ordersDomainService)
        {
            _context = context;
            _ordersDomainService = ordersDomainService;
        }

        public async Task<List<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
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
    }
}
