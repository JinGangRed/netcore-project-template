#define MSSQL 
#define Swagger
#if (MSSQL)
using Microsoft.EntityFrameworkCore;
#endif
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Template.DbDomain;
#if (Swagger)
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
#endif

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

#if (Swagger)
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(
                    name: "v1",
                    info: new Info
                    {
                        Version = "v1",
                        Title = "Template API",
                        Description = "Template Project API",
                        TermsOfService = "None",
                    });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
                options.AddSecurityDefinition("Bearer",
                    new ApiKeyScheme
                    {
                        In = "header",
                        Description = "Please input the Token(eg. MIX) from OAuth endpoint. Example: Bearer MIX",
                        Name = "Authorization",
                        Type = "apiKey"
                    });

                options.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    {
                        "Bearer",
                        Enumerable.Empty<string>()
                    }
                });
            });
        }


        public static void UseConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Template Project API");
            });
        }
#endif
    }
}
