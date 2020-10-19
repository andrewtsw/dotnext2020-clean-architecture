using Dotnext.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnext.DataAccess.Sqlite
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccessSqlite(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext<IDbContext, SqliteDbContext>(options => options
                    .UseSqlite(configuration.GetConnectionString("Dotnext2020_CleanArchitecture_Sqlite")));

            return services;
        }
    }
}
