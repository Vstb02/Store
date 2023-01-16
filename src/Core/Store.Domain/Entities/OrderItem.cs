namespace Store.Domain.Entities
{
    public class OrderItem : BaseEntity<Guid>
    {
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Order Order { get; set; }
        public Guid OrderId { get; set; }
    }
}
