namespace Store.Application.Models.Comments
{
    public record class CommentDto
    {
        public List<CommentItemDto> Items { get; init; }
        public int TotalQuantity { get; init; }
    }
}
