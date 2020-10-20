using Dotnext.ApplicationServices.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnext.ApplicationServices.Implementation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPermissionsManager, PermissionsManager>();

            return services;
        }
    }
}
