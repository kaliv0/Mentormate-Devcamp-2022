namespace MMRestaurant.Web.Controllers
{
    using MMRestaurant.Web.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        [Authorize(Roles = "Admin")]
        [HttpGet()]
        public IActionResult Orders()
        {
            var email = User.GetEmail();
            var role = User.GetRole();

            return Ok(new { Message = $"Hello, {email}! You are an {role}" });
        }
    }
}
