using Api.Infra.CrossCutting.DependecyContainer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;

namespace Api
{
    /// <summary>
    /// Program api
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main api
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            try
            {
                Log.Information("Api Started");

                CreateHostBuilder(args).Build().DbSeedData().Run();
            }
            catch (Exception e)
            {
                Log.Fatal("Api Fatal Error {exception}", e);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        /// <summary>
        /// Create host builder
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .AddSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}
