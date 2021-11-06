using Api.Infra.CrossCutting.Exceptions;
using Api.Infra.CrossCutting.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Infra.CrossCutting.Middleware
{
    /// <summary>
    /// Error handling middleware
    /// </summary>
    public class ErrorHandlingMiddleware
    {
        /// <summary>
        /// Request delegate
        /// </summary>
        private readonly RequestDelegate _next;
        
        /// <summary>
        /// Logger
        /// </summary>
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        /// <summary>
        /// Error handling middleware contructor
        /// </summary>
        /// <param name="next"></param>
        /// <param name="logger"></param>
        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        /// <summary>
        /// Method to invoke http context
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        /// <summary>
        /// Method to get handle exception
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {


            object errors = null;

            switch (exception)
            {
                case RestException re:
                    _logger.LogError(exception, "REST ERROR");
                    errors = re.Error;
                    context.Response.StatusCode = (int)re.Code;
                    LoggerPrint.WriteLog("REST ERROR", null, exception);
                    break;
                case Exception ex:
                    _logger.LogError(exception, "SERVER ERROR");
                    errors = string.IsNullOrWhiteSpace(ex.Message) ? "Error" : ex.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    LoggerPrint.WriteLog("SERVER ERROR", null, exception);
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }

            context.Response.ContentType = "application/json";
            if (errors != null)
            {
                var result = JsonSerializer.Serialize(new
                {
                    errors
                });

                await context.Response.WriteAsync(result);
            }
        }
    }
}