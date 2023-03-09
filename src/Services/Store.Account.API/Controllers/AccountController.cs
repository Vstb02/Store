using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Nest;
using Store.Account.API.Models;
using Store.Application.Common.Exceptions;
using Store.Application.Common.Helpers;
using Store.Application.Common.Identity;
using Store.Domain.Enums;
using Store.Domain.Identity;
using Store.Infrastructure.Base.Controllers;
using Store.Persistence.Contexts;

namespace Store.Account.API.Controllers
{
    public class AccountController : ApiControllerBase
    {
        private readonly IdentityDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly IPublishEndpoint _publishEndpoint;

        public AccountController(IdentityDbContext context, IMemoryCache cache, IPublishEndpoint publishEndpoint)
        {
            _context = context;
            _cache = cache;
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var defaultRole = await _context.Roles.FirstOrDefaultAsync(x => x.Name == IdentityRoles.User);

            if (defaultRole == null)
            {
                var role = new Role() { Name = IdentityRoles.User };
                await _context.Roles.AddAsync(role);
                await _context.SaveChangesAsync();
            }

            var existenceUser = await _context.Users.FirstOrDefaultAsync(x => x.UserName.Equals(request.UserName));

            if (existenceUser is not null)
            {
                return Unauthorized($"Пользователь с именем {request.UserName} уже зарегистрирован!");
            }

            var user = new User()
            {
                Id = Guid.NewGuid(),
                UserName = request.UserName,
                Role = defaultRole,
                Password = PasswordHelper.HashPassword(request.Password),
            };

            var userInfo = new UserInfo()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
            };

            userInfo.Users.Add(user);

            await _context.UserInfos.AddAsync(userInfo);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeStatus(Guid id, [FromQuery] AccountStatus status)
        {
            var user = await _context.Users.Include(x => x.UserInfos).FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (user == null)
            {
                throw new NotFoundException($"Пользователь с id {id} не найден");
            }

            user.UserInfos.AccountStatus = status;

            _cache.Set(user.Id, user);

            await _publishEndpoint.Publish<User>(user);

            _context.Update(user);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
