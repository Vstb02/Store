using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistence.Configurations
{
    public class UserInfoConfiguration : IEntityTypeConfiguration<UserInfo>
    {
        public void Configure(EntityTypeBuilder<UserInfo> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Surname)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Patronymic)
                .IsRequired(false)
                .HasMaxLength(200);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.PhoneNumber)
                .IsRequired(false)
                .HasMaxLength(20);

            builder.HasOne(x => x.Role)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.RoleId);
        }
    }
}
