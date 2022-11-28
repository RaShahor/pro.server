using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

using Entities;
using DAL;
using BL;
using Middleware;

namespace RSWebApp
{
    public class Startup
    {
        ILogger<Startup> logger;

        public Startup(IConfiguration configuration)//pushing trial!!! good-luck
        {

            Configuration = configuration;


        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<SignContext>(option => option.UseSqlServer
            (Configuration.GetConnectionString("MyPc")));
            services.AddControllers();

            //services.AddScoped<IManagerBL,ManagerBL>();
            //services.AddScoped<IManagerDL,ManagerDL>();
            services.AddScoped<IlogInBL, LogInBL>();
            services.AddScoped<ILogInDL, LogInDL>();
            services.AddScoped<IAIBL, AIBL>();
            services.AddScoped<IAIDL, AIDL>();
            services.AddScoped<ISignerBl, SignerBl>();
            services.AddScoped<ISignerDl, SignerDl>();
            services.AddScoped<IformBL, FormBL>();
            //services.AddScoped<IuserFor_managerDL, UserFor_managerDL>();
            services.AddScoped<IFormDL, FormDL>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RSWebApp", Version = "v1" });
            });
            services.AddResponseCaching();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.WithOrigins("https://localhost:4200");
                    });
            });
            


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RSWebApp v1"));
                this.logger = logger;
                try
                {
                    logger.LogInformation("startup is up?");

                }
                catch (Exception Ex) { logger.LogError(Ex.Message); }


                //finally
                //{
                //}

                app.UseStaticFiles();
                app.UseRouting();
                app.UseCors(options =>
                {
                    options.AllowAnyOrigin();
                    options.AllowAnyMethod();
                    options.AllowAnyHeader();
                });
                
                //app.UseHttpsRedirection();
                app.UseCSPMiddleware();

                app.UseResponseCaching();
                //app.Use(async (context, next) =>
                //{
                //    context.Response.Headers.Add("Context-Security-Policy",
                //        "script-src 'self';" +
                //        "style-src 'self';" +
                //        "image-src 'self'");
                //    await next();
                //});
                app.Use(async (context, next) =>
                {
                    context.Response.GetTypedHeaders().CacheControl =
                        new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                        {
                            Public = true,
                            MaxAge = TimeSpan.FromSeconds(10)
                        };
                    context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
                        new string[] { "Accept-Encoding" };

                    await next();
                });


                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            }
        }
    }
}
