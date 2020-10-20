using Dotnext.UseCases.Orders;
using Dotnext.UseCases.Orders.Commands;
using Dotnext.UseCases.Orders.Queries.GetAllOrders;
using Dotnext.UseCases.Orders.Queries.GetOrderById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dotnext.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ISender _sender;
        public OrdersController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{id}")]
        public async Task<OrderDto> GetById(int id)
        {
            return await _sender.Send(new GetOrderByIdQuery(id));
        }

        [HttpGet]
        public async Task<List<OrderDto>> GetAll()
        {
            return await _sender.Send(new GetAllOrdersQuery());
        }

        [HttpPost("{id}")]
        public async Task<OrderDto> Send(int id)
        {
            return await _sender.Send(new SendOrderCommand(id));
        }
    }
}
