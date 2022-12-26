using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infrastructure.Data.Configurations
{
    public class BasketItemConfiguration : IEntityTypeConfiguration<BasketItem>
    {
        public void Configure(EntityTypeBuilder<BasketItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Quantity)
                .IsRequired();

            builder.Property(x => x.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.HasOne(x => x.Basket)
                .WithMany(x => x.BasketItems)
                .HasForeignKey(x => x.BasketId);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.BasketItems)
                .HasForeignKey(x => x.ProductId);
        }
    }
}
