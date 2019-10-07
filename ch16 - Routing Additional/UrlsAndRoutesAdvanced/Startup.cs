using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace UrlsAndRoutes
{
    using Microsoft.AspNetCore.Routing;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(options => options.EnableEndpointRouting = false);
            services.Configure<RouteOptions>(
                opt =>
                    {
                        opt.AppendTrailingSlash = true;
                        opt.LowercaseUrls = true;
                    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseStatusCodePages();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMvc(
                routes =>
                    {
                        routes.MapRoute(
                            name: "areas",
                            template: "{area:exists}/{controller=Home}/{action=Index}");

                        /*
                        routes.MapRoute(
                            name: "ShopSchema",
                            template: "Shop/{action}",
                            defaults: new { controller = "Home" });
                        routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}");
                        routes.MapRoute(name: string.Empty, template: "public/{controller=Home}/{action=Index}");
                    */

                        //routes.MapRoute(
                        //    name: "NewRoute",
                        //    template: "App/Do{action}",
                        //    defaults: new { controller = "Home" });

                        routes.MapRoute(name: "ÌyRoute",
                            template: "{controller=Home}/{action=Index}/{id?}/{*catchall}");

                        routes.MapRoute(
                            name: "out",
                            template: "outbound/{controller=Home}/{action=Index}");

                    });
        }
    }
}