using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Store.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        internal String UserId => !User.Identity.IsAuthenticated
            ? String.Empty
            : User.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}
