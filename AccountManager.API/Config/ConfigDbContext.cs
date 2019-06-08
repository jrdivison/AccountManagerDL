using AccountManager.API.Security;
using AccountManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManager.API.Config
{
    public static class ConfigDbContext
    {
        public static IServiceCollection ConfigureServiceDbContext(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddDbContext<AccountManagerDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("default"), o =>
                {
                    o.MigrationsAssembly(
                        typeof(AccountManagerDbContext).Assembly.FullName);
                });
            });

            services.AddDbContext<SecurityDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("security"), o =>
                {
                    o.MigrationsAssembly(
                        typeof(SecurityDbContext).Assembly.FullName);
                });
            });
            return services;
        }
    }
}
