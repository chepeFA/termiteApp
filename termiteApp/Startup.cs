using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using termiteApp.Core;
using termiteApp.Infrastructure;
using termiteApp.Core.Interfaces;
using termiteApp.Core.UserCase;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.OpenApi.Models;

namespace termiteApp
{
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
            //   services.AddControllersWithViews();

            services.AddControllers();
            services.AddTransient<ISectionUserCase, SectionUserCase>();
            services.AddTransient<ISectionRepository, SectionRepository>();
            services.AddTransient<ITypeReportUserCase, TypeReportUserCase>();
            services.AddTransient<ITypeReportRepository, TypeReportRepository>();
            services.AddSwaggerGen(options =>
           {
           var groupName = "v1";
           options.SwaggerDoc(groupName, new OpenApiInfo

               {
                   Title = $"Api Netcore {groupName}",
                    Version = groupName,
                    Description = "NetCore API",

                   Contact = new OpenApiContact
                   {
                       Name = "Jose Arias",
                       Email = string.Empty,
                       //  Url = new Uri("");

                   }

               });
        });
        



            //enable CORS
            //   services.AddCors(c =>
            // {
            //   c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            //});

            //JSON serializer
            //  services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore).AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            //services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            /*
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            */
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Foo API V1");
            });

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
           {
               endpoints.MapControllers();
           });
        }
    }
}
