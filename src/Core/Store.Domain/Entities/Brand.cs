namespace Store.Domain.Entities
{
    public class Brand : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
