using AccountManager.API.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.API.Config
{
    public static class ConfigSecurity
    {
        public static IServiceCollection ConfigureServiceSecurity(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddCors();
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<SecurityDbContext>();

            var key = 
                Encoding.ASCII.GetBytes(configuration["JWT:secret"]);

            services.AddAuthentication(x => 
            {
                x.DefaultAuthenticateScheme =
                    JwtBearerDefaults.AuthenticationScheme;

                x.DefaultChallengeScheme =
                    JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x => 
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters =
                    new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
            });
            return services;
        }


        public static IApplicationBuilder ConfigureSecurity(
        this IApplicationBuilder app)
        {
            app.UseAuthentication();
            return app;
        }
    }
}
