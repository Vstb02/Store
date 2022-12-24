namespace Store.WebAPI.Models.Identity
{
    public record class LoginUserResponseDto
    {
        public Guid? Id { get; init; }
        public string AuthToken { get; init; }
    }
}
