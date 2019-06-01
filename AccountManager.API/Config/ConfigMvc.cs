using AccountManager.API.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManager.API.Config
{
    public static class ConfigMvc
    {
        public static IServiceCollection ConfigureServiceMvc(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddMvc(options => {
                options.Filters.Add(typeof(ValidModelFilterMiddleware));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            return services;
        }
    }
}
