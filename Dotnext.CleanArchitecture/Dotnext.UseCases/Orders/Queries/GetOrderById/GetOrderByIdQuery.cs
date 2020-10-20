using MediatR;

namespace Dotnext.UseCases.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<OrderDto>
    {
        public GetOrderByIdQuery(int orderId)
        {
            OrderId = orderId;
        }

        public int OrderId { get; }
    }
}
