using Api.Infra.CrossCutting.DependecyContainer;
using Api.Infra.CrossCutting.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Serilog;
using System;
using System.IO;

namespace Api
{
    /// <summary>
    /// Startup api 
    /// </summary>
    public class Startup
    {
        private IConfiguration Configuration { get; }

        /// <summary>
        /// Constructor of startup
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configuration of services collection
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiConfigurations(Configuration);

            services.AddControllers();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(
                    "Api",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "Shcedule Api",
                        Version = "1.0"
                    }
                );

                var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, "Api.xml");
                var xmlCommentsFullPathDomain = Path.Combine(AppContext.BaseDirectory, "Api.Domain.xml");
                var xmlCommentsFullPathServices = Path.Combine(AppContext.BaseDirectory, "Api.Service.xml");
                var xmlCommentsFullPathInfraData = Path.Combine(AppContext.BaseDirectory, "Api.Infra.Data.xml");

                options.IncludeXmlComments(xmlCommentsFullPath);
                options.IncludeXmlComments(xmlCommentsFullPathDomain);
                options.IncludeXmlComments(xmlCommentsFullPathServices);
                options.IncludeXmlComments(xmlCommentsFullPathInfraData);
            });
        }

        /// <summary>
        /// Configuration of application and host environment
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseAuthentication();

            app.UseCors("CorsPolicy");

            app.UseSerilogRequestLogging(options =>
            {
                var assembly = System.Reflection.Assembly.GetEntryAssembly()?.GetName().Name;
                options.MessageTemplate =
                    "{" + assembly +
                    "} HTTP {RequestMethod} {RequestPath} responded {StatusCode} in {Elapsed:0.0000} ms";
                options.EnrichDiagnosticContext = SerilogConfiguration.EnrichFromRequest;
            });

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                RequestPath = new PathString("/Resources")
            });

            //app.UseAuthentication();
            //app.UseAuthorization();

            app.UseSwagger()
                .UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("swagger/Api/swagger.json", "Api");
                    options.RoutePrefix = "";
                }    
            );

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
