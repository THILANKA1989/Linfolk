using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using NetCoreLinfolk.Data.Entities;
using NetCoreLinfolk.Data.LinfolkContext;
using NetCoreLinfolk.Services;
using Newtonsoft.Json;

namespace NetCoreLinfolk
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        private readonly IConfiguration _config;
        private readonly IHostingEnvironment _environment;

        public Startup(IConfiguration config, IHostingEnvironment environment)
        {
            _config = config;
            _environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<Author, IdentityRole>(cfg => {
                cfg.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<LinfolkContext>();

            services.AddAuthentication()
                .AddCookie()
                .AddJwtBearer(cfg => {
                    cfg.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = _config["Token:Issuer"],
                        ValidAudience = _config["Tokens:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]))
                    };
                });

            services.AddDbContext<LinfolkContext>(cfg =>
            {
                cfg.UseSqlServer(_config.GetConnectionString("LinfolkConnectionString"));
            });
            services.AddAutoMapper();
            services.AddTransient<IMailService, NullMailService>();
            services.AddTransient<LinfolkSeeder>();
            services.AddScoped<ILinfolkRepository, LinfolkRepository>();
            services.AddMvc(
                opt=> {
                    if (_environment.IsProduction())
                    {
                        opt.Filters.Add(new RequireHttpsAttribute());
                    }
                }).AddJsonOptions(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }
            app.UseAuthentication();
            app.UseMvc( cfg => {
                cfg.MapRoute("Default", "/{controller}/{action}/{id?}", new { controller = "App", action = "Index" });
            });

            if (env.IsDevelopment())
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var seeder = scope.ServiceProvider.GetService<LinfolkSeeder>();
                    seeder.Seed().Wait();
                }
            }
        }
    }
}
