namespace MMRestaurant.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MMRestaurant.Web.Extensions;
    using MMRestaurant.Business.Services;
    using MMRestaurant.Domain.Models;
    using MMRestaurant.Domain.Constants;
    using MMRestaurant.Domain.Constants.Exceptions;

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet()]
        public async Task<IActionResult> GetUsersExcludingAdminAsync(int pageStart)
        {
            try
            {
                var email = User.GetEmail();
                var users = await _userService
                    .GetAllUsersExcludingAdminAsync(email);

                var filteredUsers = users
                     .Skip((pageStart - 1) * 20)
                     .Take(20);

                return Ok(filteredUsers);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost()]
        public async Task<IActionResult> AddUserAsync([FromBody] AddOrEditUserModel newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var name = newUser.Name;
            var email = newUser.Email;
            var password = newUser.Password;
            var role = newUser.Role;

            try
            {
                await _userService.AddUserAsync(role, name, email, password);
                return Ok(UserSuccessMessages.SuccessAdd);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserByIdAsync(string userId)
        {
            try
            {
                var user = await _userService.GetUserModelByIdAsync(userId);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{userId}")]
        public async Task<IActionResult> EditUserAsync(string userId, [FromBody] AddOrEditUserModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _userService.EditUserAsync(userId, user);
                return Ok(UserSuccessMessages.SuccessEdit);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUserAsync(string userId)
        {
            var currUserId = User.GetUserId();

            if (userId == currUserId)
            {
                return BadRequest(InvalidInputErrorMessages.InvalidIdForDelete);
            }

            try
            {
                await _userService.DeleteUserByIdAsync(userId);
                return Ok(UserSuccessMessages.SuccessDelete);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> GetSelfAsync()
        {
            var currUserId = User.GetUserId();

            try
            {
                var currUser = await _userService.GetSelfByIdAsync(currUserId);
                return Ok(currUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("me")]
        public async Task<IActionResult> EditSelfAsync([FromBody] EditSelfModel user)
        {
            var currUserId = User.GetUserId();

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _userService.EditSelfAsync(currUserId, user);
                return Ok(UserSuccessMessages.SuccessEdit);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
