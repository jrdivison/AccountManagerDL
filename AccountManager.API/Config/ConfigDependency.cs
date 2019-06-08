using AccountManager.API.Filters;
using AccountManager.API.Security;
using AccountManager.Data.DataServices;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManager.API.Config
{
    public static class ConfigDependency
    {
        public static IServiceCollection ConfigureServiceDependency(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddAutoMapper();
            services.AddSingleton(configuration);
            services.AddTransient<AccountDataService>();
            services.AddTransient<AccountTypeDataService>();
            services.AddTransient<SecurityUserService>();

            return services;
        }

        public static IApplicationBuilder ConfigureDependency(
        this IApplicationBuilder app)
        {
            
            return app;
        }
    }
}
