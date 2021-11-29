using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.CustomMiddleware
{
    /// <summary>
    /// 2.2.4 - Middleware for authorization
    /// </summary>
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var auth = context.Request.Headers.ContainsKey("Authorization");
            
            if (auth)
            {
                if (context.Request.Headers["Authorization"] == "Basic admin:admin")
                {
                    await _next.Invoke(context);
                }
                else
                {
                    context.Response.StatusCode = 403;
                }
            }
            else
            {
                context.Response.StatusCode = 403;
            }
        }
    }
}
