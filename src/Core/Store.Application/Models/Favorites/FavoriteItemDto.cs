using Store.Domain.Enums;

namespace Store.Application.Models.Favorites
{
    public class FavoriteItemDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public decimal Price { get; init; }
        public double Discount { get; init; }
        public string MainImageUri { get; init; }
        public int Quantity { get; init; }
        public ProductStatus Status { get; init; }
    }
}
