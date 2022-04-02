namespace MMRestaurant.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MMRestaurant.Domain.Contracts.Services;
    using MMRestaurant.Domain.Models.Auth;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly IAuthorizeService _authorizeService;

        public AuthorizeController(IAuthorizeService authorizeService)
        {
            _authorizeService = authorizeService;
        }

        [HttpPost]
        public async Task<IActionResult> AuthorizeAsync([FromBody] AuthorizeRequest request)
        {
            try
            {
                var response = await _authorizeService.AuthorizeAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new AuthorizeErrorResponse(ex.Message));
            }
        }
    }
}
