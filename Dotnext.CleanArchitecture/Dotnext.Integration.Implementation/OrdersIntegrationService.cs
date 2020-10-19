using Dotnext.Entities;
using Dotnext.Integration.Interfaces;
using System.Threading.Tasks;

namespace Dotnext.Integration.Implementation
{
    public class OrdersIntegrationService : IOrdersIntegrationService
    {
        public Task<string> SendOrderAsync(Order order)
        {
            // TODO:
            return Task.FromResult($"external-id-{order.Id}");
        }
    }
}
