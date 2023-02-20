using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Identity.API.Data.Entities;

namespace Store.Identity.API.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Name)
                .IsRequired(false)
                .HasMaxLength(200);

            builder.Property(x => x.Surname)
                .IsRequired(false)
                .HasMaxLength(200);

            builder.Property(x => x.Patronymic)
                .IsRequired(false)
                .HasMaxLength(200);

            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasOne(x => x.Role)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.RoleId);
        }
    }
}
