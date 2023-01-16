namespace Store.Application.Models.Raitings
{
    public record class RatingDto
    {
        public Guid Id { get; init; }
        public int Value { get; init; }
    }
}
