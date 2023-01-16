namespace Store.Domain.Entities
{
    public class Address : BaseEntity<Guid>
    {
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Place { get; set; }
        public string Index { get; set; }
        public string BuyerId { get; set; }
        public List<Order> Orders { get; set; }
    }
}
