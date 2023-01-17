namespace Store.Domain.Entities
{
    public class Rating : BaseEntity<Guid>
    {
        public int Value { get; set; } 
        public string AuthorId { get; set; }
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
    }
}
