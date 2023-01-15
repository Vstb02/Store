using Store.Domain.Enums;

namespace Store.Domain.Entities
{
    public class Product : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public double Discount { get; set; }
        public string MainImageUri { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public string Slug { get; set; }
        public int Quantity { get; set; }
        public ProductStatus Status { get; set; }
        public ProductCategory Category { get; set; }
        public Guid CategoryId { get; set; }
        public List<BasketItem> BasketItems { get; set; }
        public Brand Brand { get; set; }
        public Guid BrandId { get; set; }
        public List<Favorite> Favorites { get; set; }
    }
}
