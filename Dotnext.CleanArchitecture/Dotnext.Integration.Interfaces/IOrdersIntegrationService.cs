using Dotnext.Entities;
using System.Threading.Tasks;

namespace Dotnext.Integration.Interfaces
{
    public interface IOrdersIntegrationService
    {
        Task<string> SendOrderAsync(Order order);
    }
}
