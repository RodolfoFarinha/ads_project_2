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
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

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