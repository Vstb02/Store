namespace Store.Domain.Entities
{
    public class BasketItem : BaseEntity<Guid>
    {
        public Product Product { get; set; }
        public Guid ProductId { get; set; } 
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Basket Basket { get; set; }
        public Guid BasketId { get; set; }
    }
}
