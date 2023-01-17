using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces;
using Store.Domain.Identity;
using Store.WebAPI.Models.Identity;

namespace Store.WebAPI.Controllers
{
    public class AccountController : ApiControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly ITokenClaimsService _tokenClaimsService;
        public AccountController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 ILogger<AccountController> logger,
                                 ITokenClaimsService tokenClaimsService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _tokenClaimsService = tokenClaimsService;
        }

        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="200">Success</response>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserRequestDto request)
        {
            var userEntity = await _userManager.FindByNameAsync(request.UserName);

            if (userEntity == null)
            {
                return Unauthorized(new { ErrorMessage = "Пользователь не найден" });
            }

            var result = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, request.RemeberMe, false);

            if (!result.Succeeded)
            {
                return Unauthorized(new { ErrorMessage = "Неправильный логин или пароль" });
            }

            var response = new LoginUserResponseDto()
            {
                Id = Guid.Parse(userEntity.Id),
                AuthToken = await _tokenClaimsService.GetTokenAsync(userEntity)
            };

            return Ok(response);
        }
    }
}
