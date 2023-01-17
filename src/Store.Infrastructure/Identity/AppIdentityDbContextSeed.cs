using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Store.Application.Common.Identity;
using Store.Domain.Identity;

namespace Store.Infrastructure.Identity
{
    public static class AppIdentityDbContextSeed
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager,
                                           RoleManager<IdentityRole> roleManager,
                                           IConfiguration configuration)
        {
            await roleManager.CreateAsync(new IdentityRole(IdentityRoles.Admin));
            await roleManager.CreateAsync(new IdentityRole(IdentityRoles.User));
            await roleManager.CreateAsync(new IdentityRole(IdentityRoles.Operator));

            var password = configuration.GetSection("Identity:DefaultPassword").Value;

            string defaultUserName = "user";
            var defaultUser = new ApplicationUser { UserName = defaultUserName, Email = "user@gmail.com" };
            await userManager.CreateAsync(defaultUser, password);
            defaultUser = await userManager.FindByNameAsync(defaultUserName);
            await userManager.AddToRoleAsync(defaultUser, IdentityRoles.User);
            

            string adminUserName = "admin";
            var adminUser = new ApplicationUser { UserName = adminUserName, Email = adminUserName };
            await userManager.CreateAsync(adminUser, password);
            adminUser = await userManager.FindByNameAsync(adminUserName);
            await userManager.AddToRoleAsync(adminUser, IdentityRoles.Admin);
        }
    }
}
