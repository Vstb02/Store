using Store.Domain.Entities;
using Store.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Models.Baskets
{
    public record class BasketItemDto
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
