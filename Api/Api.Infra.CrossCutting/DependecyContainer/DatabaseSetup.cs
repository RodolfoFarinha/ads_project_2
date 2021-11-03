using Api.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Api.Infra.CrossCutting.DependecyContainer
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException($"{nameof(services)} - Services weren't loaded correctly");

            services.AddScoped<ApiDBContext>();

            services.AddDbContext<ApiDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ApiDBConnection"),
                    x => x.MigrationsHistoryTable(("__EFMigrationsHistory_Data")));
            });
        }
    }
}
