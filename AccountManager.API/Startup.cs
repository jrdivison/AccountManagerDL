using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountManager.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using AccountManager.Data.DataServices;
using AutoMapper;
using Swashbuckle.AspNetCore.Swagger;
using AccountManager.API.Filters;
using AccountManager.API.Security;
using AccountManager.API.Config;

namespace AccountManager.API
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

            services.ConfigureServiceDbContext(Configuration);
            services.ConfigureServiceSecurity(Configuration);
            services.ConfigureServiceDependency(Configuration);
            services.ConfigureServiceSwagger(Configuration);
            services.ConfigureServiceMvc(Configuration);                     
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.ConfigureSwagger();
            app.UseHttpsRedirection();
            app.UseMiddleware(typeof(ErrorHandlerFilterMiddleware));
            app.UseMvc();
        }
    }
}
