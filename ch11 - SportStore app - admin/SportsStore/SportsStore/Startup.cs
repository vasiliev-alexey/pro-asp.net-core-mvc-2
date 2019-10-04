namespace SportsStore
{
    using System;
    using System.Globalization;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Localization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    using SportsStore.Models;
    using SportsStore.Models.Domain;
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
            services.AddSession(options =>
                {
                    // Set a short timeout for easy testing.
                    options.IdleTimeout = TimeSpan.FromHours(1);
                    options.Cookie.HttpOnly = true;
                    // Make the session cookie essential
                    options.Cookie.IsEssential = true;
                });

            services.AddControllersWithViews(options => options.EnableEndpointRouting = false);
            services.AddDbContext<ApplicationDbContext>();
            services.AddTransient<IProductRepository, EfProductRepository>();
            services.AddTransient<IOrderRepository, EFOrderRepository>();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

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

            // ���� ����������� ����� �������� ��,������� ��� ������������ ������������ ����������� �� ����� wwwroot
            app.UseStaticFiles();

            /*
             ���� ����������� ����� ��������� ������� ���������
              � ����-������, ������� ����� �� ����� �� ����, �����
               ��� ������ 404 - Not Found(404 - �� �������)
            */
            app.UseStatusCodePages();

            app.UseRouting();

            app.UseAuthorization();

            //var supportedCultures = new[]
            //                            {
            //                                new CultureInfo("en-US"),
            //                                new CultureInfo("ru-ru"),
            //                            };

            //app.UseRequestLocalization(new RequestLocalizationOptions
            //                               {
            //                                   DefaultRequestCulture = new RequestCulture("ru-RU"),
            //                                   // Formatting numbers, dates, etc.
            //                                   SupportedCultures = supportedCultures,
            //                                   // UI strings that we have localized.
            //                                   SupportedUICultures = supportedCultures
            //                               });

       
                app.UseRequestLocalization();

                CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
                CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");


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