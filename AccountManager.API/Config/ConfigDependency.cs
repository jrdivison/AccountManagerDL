using AccountManager.Data.DataServices;
using AutoMapper;
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

            return services;
        }
    }
}
