using MediatR;

namespace Dotnext.UseCases.Orders.Commands
{
    public class SendOrderCommand :IRequest<OrderDto>
    {
        public SendOrderCommand(int orderId)
        {
            OrderId = orderId;
        }

        public int OrderId { get;  }
    }
}
