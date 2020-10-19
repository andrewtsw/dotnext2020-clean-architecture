using Dotnext.Integration.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnext.Integration.Implementation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddOrdersIntegration(this IServiceCollection services)
        {
            services.AddScoped<IOrdersIntegrationService, OrdersIntegrationService>();

            return services;
        }
    }
}
