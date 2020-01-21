using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace ASP
{
    public class AuthenticationMiddleware
    {
        private RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["token"];
            if (String.IsNullOrEmpty(token))
                context.Response.StatusCode = 403;
            else
                await _next(context);
        }
    }
}