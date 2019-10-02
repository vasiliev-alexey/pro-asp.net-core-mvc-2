namespace SportsStore
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    using SportsStore.Models;
    using SportsStore.Models.Interfaces;
    using SportsStore.Models.Repositories;

    /// <summary>
    /// The startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        ///  This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSession();

            services.AddControllersWithViews(options => options.EnableEndpointRouting = false);
            services.AddDbContext<ApplicationDbContext>();
            services.AddTransient<IProductRepository, EfProductRepository>();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">
        /// The ApplicationBuilder.
        /// </param>
        /// <param name="env">
        /// The WebHostEnvironment.
        /// </param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            // Ётот расшир€ющий метод включает по,одержку дл€ обслуживани€ статического содержимого из папки wwwroot
            app.UseStaticFiles();

            /*
             Ётот расшир€ющий метод добавл€ет простое сообщение
              в Ќ““–-ответы, которые иначе не имели бы тела, такие
               как ответы 404 - Not Found(404 - не найдено)
            */
            app.UseStatusCodePages();

            app.UseRouting();

            app.UseAuthorization();



            // app.UseEndpoints(
            // endpoints =>
            // {
            // endpoints.MapControllers();
            // endpoints.MapControllerRoute(
            // name: "pagination",
            // pattern: "Products/Page{productPage}");
            // endpoints.MapControllerRoute(
            // name: "default",
            // pattern: "{controller=Home}/{action=Index}/{id?}");

            // });
            app.UseSession();
            app.UseMvc(
                routes =>
                    {
                        routes.MapRoute(
                            name: null,
                            "{category}/Page{productPage:int}",
                            defaults: new { controller = "Product", action = "List" });
                 
                        routes.MapRoute(
                            null,
                            "Page{productPage:int}",
                            defaults: new { controller = "Product", action = "List", productPage = 1 });
                        routes.MapRoute(
                            null,
                            "{category}",
                            defaults: new { controller = "Product", action = "List", productPage = 1 });
                        routes.MapRoute(
                            null,
                            "",
                            defaults: new { controller = "Product", action = "List", productPage = 1 });
                        routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");

                    });

            SeedData.EnsurePopulated(app);
        }
    }
}