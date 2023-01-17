namespace Store.Application.Models.Comments
{
    public record class CreateCommentDto
    {
        public string Content { get; init; }
    }
}
