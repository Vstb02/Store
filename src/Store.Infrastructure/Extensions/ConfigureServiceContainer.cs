using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Application.Interfaces;
using Store.Application.Services;
using Store.Infrastructure.Identity;

namespace Store.Infrastructure.Extensions
{
    public static class ConfigureServiceContainer
    {
        public static void ConfigureDbContext(this IServiceCollection services,
             IConfiguration configuration)
        {
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("IdentityConnection")));

            services.AddScoped<ITokenClaimsService, TokenClaimsService>();
        }
    }
}
