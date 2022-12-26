using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infrastructure.Data.Configurations
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired(false)
                .HasMaxLength(300);

            builder.Property(x => x.ImageUri)
                .IsRequired(true)
                .HasMaxLength(255);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductImages)
                .HasForeignKey(x => x.ProductId);
        }
    }
}
