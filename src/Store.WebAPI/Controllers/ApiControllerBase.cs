using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Domain.Identity;
using System.Security.Claims;

namespace Store.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        internal String UserId => !User.Identity.IsAuthenticated
            ? String.Empty
            : User.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}
