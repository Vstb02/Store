using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infrastructure.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(x => x.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.Status)
                .IsRequired();

            builder.Property(x => x.Slug)
                .IsRequired(true)
                .HasMaxLength(250);

            builder.Property(x => x.MainImageUri)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Quantity)
                .IsRequired();

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
