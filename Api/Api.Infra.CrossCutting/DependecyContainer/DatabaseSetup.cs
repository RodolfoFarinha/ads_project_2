using Api.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Api.Infra.CrossCutting.DependecyContainer
{
    /// <summary>
    /// Database setup configuration
    /// </summary>
    public static class DatabaseSetup
    {
        /// <summary>
        /// Method to add database setup configuration
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException($"{nameof(services)} - Services weren't loaded correctly");

            services.AddScoped<ApiDBContext>();

            services.AddDbContext<ApiDBContext>(options =>
            {
                // For Mysql Database
                options.UseMySQL(configuration.GetConnectionString("ApiDBConnection"), 
                    x => x.MigrationsHistoryTable(("__EFMigrationsHistory_Data")));

                // For SqlServer Database
                //options.UseSqlServer(configuration.GetConnectionString("ApiDBConnection"),
                //    x => x.MigrationsHistoryTable(("__EFMigrationsHistory_Data")));
            });
        }
    }
}
