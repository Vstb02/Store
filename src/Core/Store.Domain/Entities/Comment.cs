namespace Store.Domain.Entities
{
    public class Comment : BaseEntity<Guid>
    {
        public string Content { get; set; }
        public string AuthorId { get; set; }
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
    }
}
