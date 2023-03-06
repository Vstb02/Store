namespace Store.Domain.Entities
{
    public abstract class BaseEntity<T>
    {
        public T Id { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime Updated { get; set; }
    }
}
