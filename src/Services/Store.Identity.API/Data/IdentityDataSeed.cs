

using Store.Application.Common.Identity;
using Store.Identity.API.Data.Entities;
using Store.Identity.API.Helpers;

namespace Store.Identity.API.Data
{
    public static class IdentityDataSeed
    {
        public static async Task SeedAsync(IdentityDbContext context, IConfiguration configuration)
        {
            var adminRole = await context.Roles.AddAsync(new Role { Name = IdentityRoles.Admin });
            var operatorRole = await context.Roles.AddAsync(new Role { Name = IdentityRoles.Operator });
            var userRole = await context.Roles.AddAsync(new Role { Name = IdentityRoles.User });
            await context.SaveChangesAsync();

            var password = configuration.GetSection("Identity:DefaultPassword").Value;

            string defaultUserName = "user";
            string defaultAdminName = "admin";

            // user
            await context.Users.AddAsync(new User
            {
                UserName = defaultUserName,
                Role = userRole.Entity,
                Email = "User@gmail.com",
                Password = PasswordHelper.HashPassword(password),
            });

            // admin
            await context.Users.AddAsync(new User
            {
                UserName = defaultAdminName,
                Role = adminRole.Entity,
                Email = "Admin@gmail.com",
                Password = PasswordHelper.HashPassword(password),
            });


            await context.SaveChangesAsync();
        }
    }
}
