using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace ASP
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            DefaultFilesOptions opt = new DefaultFilesOptions();
            opt.DefaultFileNames.Clear();
            opt.DefaultFileNames.Add("hello.html");

            app.UseDefaultFiles(opt);
            app.UseStaticFiles();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("hello world");
            });
        }
    }
}