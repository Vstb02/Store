namespace Store.Domain.Entities
{
    public class ProductCategory : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public List<Product> Products { get; set; }
    }
}
