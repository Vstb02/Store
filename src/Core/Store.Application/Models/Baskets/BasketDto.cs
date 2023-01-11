using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Models.Baskets
{
    public record class BasketDto
    {
        public List<BasketItemDto> Items { get; init; }
        public int TotalQuantity { get; init; }
        public decimal TotalPrice { get; init; }
    }
}
