using Dotnext.DomainServices.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnext.DomainServices.Implementation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IOrdersDomainService, OrdersDomainService>();

            return services;
        }
    }
}
