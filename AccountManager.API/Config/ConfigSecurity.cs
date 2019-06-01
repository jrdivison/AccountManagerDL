namespace AccountManager.API.Config
{
    using AccountManager.API.Security;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System.Text;

    public static class ConfigSecurity
    {
        public static IServiceCollection ConfigureService(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<SecurityDbContext>();

            var key = Encoding.ASCII.GetBytes(configuration["JWT:secret"]);
            return services;
        }
    }
}
