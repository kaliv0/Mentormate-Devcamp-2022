namespace MMRestaurant.Web.Controllers
{
    using MMRestaurant.Domain.Configuration;
    using MMRestaurant.Web.Extensions;
    using MMRestaurant.Web.Models.Auth;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Net.Mail;
    using MMRestaurant.Data.Entities;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private const string LoginError = "A user with the provided email address and password was not found";
        private const string InvalidEmailError = "Invalid email address";
        private const string MissingEmailError = "Email address is required";
        private const string MissingPasswordError = "Password is required";

        private readonly AuthOptions _options;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AuthorizeController(
            AuthOptions options,
            SignInManager<User> signInManager,
            UserManager<User> userManager)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        [HttpPost]
        public async Task<IActionResult> AuthorizeAsync([FromBody] AuthorizeRequest request)
        {
            //validating email
            var email = request.Email;
            if (email == null)
            {
                return BadRequest(new AuthorizeErrorResponse(MissingEmailError));
            }

            try
            {
                var validEmail = new MailAddress(email).Host.Contains(".");
            }
            catch (Exception)
            {
                return BadRequest(new AuthorizeErrorResponse(InvalidEmailError));
            }

            //validating password
            var password = request.Password;
            if (password == null)
            {
                return BadRequest(new AuthorizeErrorResponse(MissingPasswordError));
            }

            //find user in db
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return BadRequest(new AuthorizeErrorResponse(LoginError));
            }

            var signInResult = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);
            if (!signInResult.Succeeded)
            {
                return BadRequest(new AuthorizeErrorResponse(LoginError));
            }

            //issuing token
            var response = new AuthorizeResponse
            {
                AccessToken = await GetAccessTokenAsync(user),
                TokenType = "Bearer",
                ExpiresIn = _options.TokenLifetimeSeconds
            };

            return Ok(response);
        }

        private async Task<string> GetAccessTokenAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var signingKey = new SymmetricSecurityKey(_options.SecurityKeyAsBytes);
            var roles = await _userManager.GetRolesAsync(user);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(GetClaims(user, roles)),
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature),
                Issuer = _options.Issuer,
                Audience = _options.Audience,
                Expires = DateTime.UtcNow.AddSeconds(_options.TokenLifetimeSeconds)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(securityToken);
        }

        private static IEnumerable<Claim> GetClaims(IdentityUser user, IEnumerable<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString())
            };

            if (!roles.IsNullOrEmpty())
            {
                claims.Add(new Claim("role", roles.FirstOrDefault()));
            }

            return claims;
        }
    }
}
