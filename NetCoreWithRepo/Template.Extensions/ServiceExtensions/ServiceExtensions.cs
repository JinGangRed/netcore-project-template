using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Template.Extensions.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static void ConfigurationServices(this IServiceCollection services)
        {

        }

        public static void ConfigureDbContext(this IServiceCollection services,IConfiguration configuration)
        {
#if (MSSQL)
            services.ConfigureSqlServerContext(configuration);
#endif
#if (MYSQL)
            services.ConfigureMySqlContext(configuration);
#endif
        }

        public static void ConfigurationRepository(this IServiceCollection services)
        {

        }
    }
}
