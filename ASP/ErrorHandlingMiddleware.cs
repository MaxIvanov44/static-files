using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ASP
{
    public class ErrorHandlingMiddleware
    {
        private RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);
            if (context.Response.StatusCode == 403)
                await context.Response.WriteAsync("Доступ запрещён!");
            else if (context.Response.StatusCode == 404)
                await context.Response.WriteAsync("Не найдено!");
        }
    }
}