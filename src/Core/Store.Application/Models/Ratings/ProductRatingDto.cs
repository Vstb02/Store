namespace Store.Application.Models.Raitings
{
    public record class ProductRatingDto
    {
        public double TotalValue { get; init; }
        public Guid ProductId { get; init; }
    }
}
