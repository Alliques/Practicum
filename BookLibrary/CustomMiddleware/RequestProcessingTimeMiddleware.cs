using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.CustomMiddleware
{
    /// <summary>
    /// 2.2.3 - Request processing time logging in middleware
    /// </summary>
    public class RequestProcessingTimeMiddleware
    {
        private RequestDelegate _next;
        private readonly ILogger _logger;
        public RequestProcessingTimeMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestProcessingTimeMiddleware>();
        }
        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation("Request started: {0}.\n Method: {1} \n ",
                DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.fff"), context.Request.Method);
            var auth = context.Request.Headers.ContainsKey("Authorization");

            if (auth)
            {
                if (context.Request.Headers["Authorization"] == "Basic admin:admin")
                {
                    await _next.Invoke(context);
                    _logger.LogInformation("Request completed: {0} \n Status code: {1}",
                        DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.fff"), context.Response.StatusCode);
                }
                else
                {
                    context.Response.StatusCode = 403;
                    _logger.LogInformation("Request completed: {0} \n Status code: {1}",
                        DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.fff"), context.Response.StatusCode);
                }
            }
            else
            {
                context.Response.StatusCode = 403;
                _logger.LogInformation("Request completed: {0} \n Status code: {1}",
                        DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.fff"), context.Response.StatusCode);
            }
        }
    }
}
