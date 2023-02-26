using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Store.Infrastructure.Base.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        public String UserId => !User.Identity.IsAuthenticated
            ? String.Empty
            : User.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}
