using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LanguageFeatures
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddMvcCore( ).AddRazorPages();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            //  app.UseMvcWithDefaultRoute();
            //   app.UseRouting();
            //   app.UseAuthentication();
            //  app.UseAuthorization();

            /*            app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapGet("/", async context =>
                            {
                                await context.Response.WriteAsync("Hello World!");
                            });
                        });
            */
            app.UseRouting( );
        
            app.UseEndpoints(endpoints =>

            {
                endpoints.MapControllerRoute(
                    name: "areaRoute",
                    pattern: "{area:exists}/{controller}/{action}",
                    defaults: new { action = "Index" });


                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
 

        }
    }
}
