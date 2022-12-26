namespace Store.Domain.Entities
{
    public class Basket : BaseEntity<Guid>
    {
        public string BuyerId { get; set; }
        public List<BasketItem> BasketItems { get; set; }
    }
}
