using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Users.Infrastructure;
using Users.Models;

namespace Users
{
    using System.Security.Claims;

    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.Extensions.DependencyModel.Resolution;

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
            services.AddControllersWithViews(opt => { opt.EnableEndpointRouting = false; });

            services.AddDbContext<AppIdentityDbContext>();
            services.AddIdentity<AppUser, IdentityRole>(
                opts =>
                    {
                        opts.User.RequireUniqueEmail = true;

                        // opts.User.AllowedUserNameCharacters = @"abcdefghijklmnopqrstuvwxyz";
                        opts.Password.RequiredLength = 6;
                        opts.Password.RequireNonAlphanumeric = false;
                        opts.Password.RequireLowercase = false;
                        opts.Password.RequireUppercase = false;
                        opts.Password.RequireDigit = false;
                    }).AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();

            services.AddTransient<IPasswordValidator<AppUser>, CustomPasswordValidator>();
            services.AddTransient<IUserValidator<AppUser>, CustomUserValidator>();
            services.AddSingleton<IClaimsTransformation, LocationClaimsProvider>();
            services.AddTransient<IAuthorizationHandler, BlockUsersHandler>();

            services.AddTransient<IAuthorizationHandler, DocumentAuthorizationHandler>();

            services.AddAuthorization(
                opt =>
                    {
                        opt.AddPolicy(
                            "DCUsers",
                            policy =>
                                {
                                    policy.RequireRole("users");
                                    policy.RequireClaim(ClaimTypes.StateOrProvince, "DC");
                                });
                        opt.AddPolicy(
                            "NotBob",
                            policy =>
                                {
                                    policy.RequireAuthenticatedUser();
                                    policy.AddRequirements(new BlockUsersRequirement("Bob"));
                                });

                        opt.AddPolicy(
                            "AuthorsAndEditors",
                            policy =>
                                {
                                    policy.AddRequirements(
                                        new DocumentAuthorizationRequirement
                                            {
                                                AllowAuthors = true, AllowEditors = true
                                            });
                                });
                    });
        }
   
 

// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseAuthentication();
          
            app.UseMvcWithDefaultRoute();

            // AppIdentityDbContext.CreateAdminAccount(app.ApplicationServices, Configuration).Wait();
        }
    }
}