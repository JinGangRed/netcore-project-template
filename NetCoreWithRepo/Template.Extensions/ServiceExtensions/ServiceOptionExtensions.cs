#if (MSSQL)
using Microsoft.EntityFrameworkCore;
#endif
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Template.DbDomain;

namespace Template.Extensions.ServiceExtensions
{
    public static class ServiceOptionExtensions
    {
#if (MSSQL)
        public static void ConfigureSqlServerContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");
            services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
#endif

#if (MYSQL)
        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration configuration)
        {

        }
#endif

    }
}
