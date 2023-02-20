namespace Store.Identity.API.Models
{
    public class LoginResponse
    {
        public Guid Id { get; set; }
        public string AuthToken { get; set; }
    }
}
