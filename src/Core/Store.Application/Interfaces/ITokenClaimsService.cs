using Store.Domain.Identity;

namespace Store.Application.Interfaces
{
    public interface ITokenClaimsService
    {
        Task<string> GetTokenAsync(ApplicationUser user);
    }
}
