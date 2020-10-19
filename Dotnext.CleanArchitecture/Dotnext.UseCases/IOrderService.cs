using Dotnext.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dotnext.UseCases
{
    public interface IOrderService
    {
        Task<OrderDto> GetByIdAsync(int id);

        Task<List<OrderDto>> GetAllAsync();
    }
}
