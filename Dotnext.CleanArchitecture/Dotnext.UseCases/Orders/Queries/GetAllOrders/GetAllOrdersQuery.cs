using MediatR;
using System.Collections.Generic;

namespace Dotnext.UseCases.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQuery : IRequest<List<OrderDto>>
    {
    }
}
