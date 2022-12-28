namespace Store.Application.Models.Categories
{
    public record class CategoryDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
    }
}
