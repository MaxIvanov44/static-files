using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace ASP
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Map("/home", home =>
            {
                home.Map("/index", (appBuilder) =>
                {
                    appBuilder.Run(async (context) =>
                        await context.Response.WriteAsync("<h1>HomePage</h1>"));
                });
               
                app.Map("/about", About);
            });


            

            

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Not found!");
            });
            
        }
        private void About(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("<h2>About</h2>");
            });
        }
    }
}