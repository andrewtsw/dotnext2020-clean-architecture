using Dotnext.UseCases;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dotnext.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{id}")]
        public async Task<OrderDto> GetById(int id)
        {
            return await _orderService.GetByIdAsync(id);
        }

        [HttpGet]
        public async Task<List<OrderDto>> GetAll()
        {
            return await _orderService.GetAllAsync();
        }

        [HttpPost("{id}")]
        public async Task<OrderDto> Send(int id)
        {
            return await _orderService.SendAsync(id);
        }
    }
}
