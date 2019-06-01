using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManager.API.Config
{
    public static class ConfigSwagger
    {
        public static IServiceCollection ConfigureServiceSwagger(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Demo API",
                    Version = "v1"
                });
            });
            return services;
        }

        public static IApplicationBuilder ConfigureSwagger(
            this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Demo");
                c.RoutePrefix = string.Empty;
            });
            return app;
        }
    }
}
