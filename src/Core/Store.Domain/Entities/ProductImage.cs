namespace Store.Domain.Entities
{
    public class ProductImage : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string ImageUri { get; set; }
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
    }
}
