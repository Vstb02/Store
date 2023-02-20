using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Identity.API.Data;
using Store.Identity.API.Helpers;
using Store.Identity.API.Models;
using Store.Identity.API.Services;

namespace Store.Identity.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ITokenClaimsService _tokenClaimsService;
        private readonly IConfiguration _config;
        private readonly IdentityDbContext _context;

        public AccountController(ITokenClaimsService tokenClaimsService,
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
            await IdentityDataSeed.SeedAsync(_context, _config);

            var user = await _context.Users.Include(x => x.Role)
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
