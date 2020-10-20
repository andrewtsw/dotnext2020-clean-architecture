using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Dotnext.UseCases
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
