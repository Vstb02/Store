using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Store.Domain.Identity;
using System.Net;
using System.Security.Claims;

namespace Store.Infrastructure.Middlewares
{
    public class CheckUserMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMemoryCache _cache;

        public CheckUserMiddleware(RequestDelegate next, IMemoryCache cache)
        {
            _next = next;
            _cache = cache;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var userId = context.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (userId is null)
            {
                await _next(context);
            }

            var userIsBlocked = await IsUserBlockedAsync(userId);

            if (userIsBlocked)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                await context.Response.WriteAsync("You are blocked!");
                return;
            }

            await _next(context);
        }

        private Task<bool> IsUserBlockedAsync(string userId)
        {
            User user = _cache.Get(userId) as User;
            return Task.FromResult(false);
        }
    }
}
