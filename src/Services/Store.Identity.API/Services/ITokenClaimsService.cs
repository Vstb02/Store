using Store.Domain.Identity;
using Store.Identity.API.Data.Entities;

namespace Store.Identity.API.Services
{
    public interface ITokenClaimsService
    {
        Task<string> GetTokenAsync(User user);
    }
}
