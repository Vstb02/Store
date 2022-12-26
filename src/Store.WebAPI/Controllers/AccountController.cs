﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces;
using Store.Domain.Identity;
using Store.WebAPI.Models;
using Store.WebAPI.Models.Identity;
using Swashbuckle.AspNetCore.Annotations;

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
        /// <response code="403">Forbidden</response>
        /// <response code="200">Success</response>
        [HttpPost]
        [SwaggerOperation(
            Summary = "Authenticates a user",
            Description = "Authenticates a user",
            OperationId = "auth.authenticate",
            Tags = new[] { "AuthEndpoints" })
        ]
        public async Task<IActionResult> Login(LoginUserRequestDto request)
        {
            try
            {
                var userEntity = await _userManager.FindByNameAsync(request.UserName);

                if (userEntity == null)
                {
                    return StatusCode(403, new Response<LoginUserResponseDto>(403, "Пользователь не найден!"));
                }

                var result = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, request.RemeberMe, false);

                if (!result.Succeeded)
                {
                    return StatusCode(403, new Response<LoginUserResponseDto>(403, $"Неправильный логин или пароль"));
                }

                var response = new LoginUserResponseDto()
                {
                    Id = Guid.Parse(userEntity.Id),
                    AuthToken = await _tokenClaimsService.GetTokenAsync(userEntity)
                };

                return Ok(new Response<LoginUserResponseDto>(200, response));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ошибка при авторизации {request.UserName}");
                return BadRequest(new Response<LoginUserResponseDto>(500, "Ошибка авторизации"));
            }
        }
    }
}