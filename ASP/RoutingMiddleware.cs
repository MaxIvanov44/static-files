using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ASP
{
    public class RoutingMiddleware
    {
        private RequestDelegate _next;

        public RoutingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string path = context.Request.Path.Value.ToLower();
            if (path == "/" || path == "/index")
                await context.Response.WriteAsync("Home Page");
            else if (path == "/about")
                await context.Response.WriteAsync("About");
            else
                context.Response.StatusCode = 404;
        }
    }
}