using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Linq;
using System.Security.Claims;

namespace Api.Indra.CrossCutting.DependecyContainer
{
    /// <summary>
    /// Serilog configuration
    /// </summary>
    public static class SerilogConfiguration
    {
        /// <summary>
        /// Method to add serilog on builder
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IHostBuilder AddSerilog(this IHostBuilder builder)
        {
            builder.UseSerilog();
            return builder;
        }

        /// <summary>
        /// Method to enrich from request
        /// </summary>
        /// <param name="diagnosticContext"></param>
        /// <param name="httpContext"></param>
        public static void EnrichFromRequest(IDiagnosticContext diagnosticContext, HttpContext httpContext)
        {
            var request = httpContext.Request;
            var response = httpContext.Response;

            diagnosticContext.Set("Host", request.Host);
            diagnosticContext.Set("Protocol", request.Protocol);
            diagnosticContext.Set("Scheme", request.Scheme);

            var user = httpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            if (httpContext.User != null)
                diagnosticContext.Set("User", user);

            if (request.QueryString.HasValue)
                diagnosticContext.Set("QueryString", request.QueryString);

            diagnosticContext.Set("ContentType", response.ContentType);

            var endPoint = httpContext.GetEndpoint();
            if (endPoint != null) diagnosticContext.Set("EndpointName", endPoint.DisplayName);
        }
    }
}