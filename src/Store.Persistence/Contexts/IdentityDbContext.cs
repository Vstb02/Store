using Microsoft.EntityFrameworkCore;
using Store.Domain.Identity;
using Store.Persistence.Configurations;
namespace Store.Persistence.Contexts
{
    public class IdentityDbContext : DbContext
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserInfoConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
