using Store.Domain.Enums;

namespace Store.Domain.Entities
{
    public class Order : BaseEntity<Guid>
    {
        public Address Address { get; set; }
        public Guid AddressId { get; set; }
        public Contact Contact { get; set; }
        public Guid ContactId { get; set; }
        public string BuyerId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
