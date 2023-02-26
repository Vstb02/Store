using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Application.Common.Helpers;
using Store.Application.Interfaces;
using Store.Identity.API.Models;
using Store.Infrastructure.Base.Controllers;
using Store.Persistence.Contexts;

namespace Store.Identity.API.Controllers
{
    public class IdentityController : ApiControllerBase
    {
        private readonly ITokenClaimsService _tokenClaimsService;
        private readonly IConfiguration _config;
        private readonly IdentityDbContext _context;

        public IdentityController(ITokenClaimsService tokenClaimsService,
                                 IConfiguration config,
                                 IdentityDbContext context)
        {
            _tokenClaimsService = tokenClaimsService;
            _config = config;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var user = await _context.Users.Include(x => x.UserInfos)
                .ThenInclude(x => x.Role)
                .FirstOrDefaultAsync(x => x.UserName.ToLower() == request.UserName.ToLower().Trim());

            if (user == null)
            {
                return Unauthorized(new { ErrorMessage = "Пользователь не найден" });
            }

            var result = PasswordHelper.ComparePasswordWithHash(request.Password, user.Password);

            var response = new LoginResponse()
            {
                Id = user.Id,
                AuthToken = await _tokenClaimsService.GetTokenAsync(user)
            };

            return Ok(response);
        }
    }
}
