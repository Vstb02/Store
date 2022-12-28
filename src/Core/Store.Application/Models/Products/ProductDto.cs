using Store.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Store.Application.Models.Products
{
    public record class ProductDto
    {
        public ProductDto()
        {
            ProductImages = new List<ProductImageDto>();
        }

        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public decimal Price { get; init; }
        public double Discount { get; set; }
        public string MainImageUri { get; set; }
        public IEnumerable<ProductImageDto> ProductImages { get; set; }
        public int Quantity { get; set; }
        [Required]
        public ProductStatus Status { get; set; }
    }
}
