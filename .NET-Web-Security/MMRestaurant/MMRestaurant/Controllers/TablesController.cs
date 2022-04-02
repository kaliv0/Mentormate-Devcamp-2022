namespace MMRestaurant.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TablesController : ControllerBase
    {
        [HttpGet()]
        public IActionResult Tables()
        {
            return Ok("Tables");
        }
    }
}
