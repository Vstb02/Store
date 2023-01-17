namespace Store.Domain.Entities
{
    public class Favorite : BaseEntity<Guid>
    {
        public string BuyerId { get; set; }
        public List<Product> Products { get; set; }
    }
}
