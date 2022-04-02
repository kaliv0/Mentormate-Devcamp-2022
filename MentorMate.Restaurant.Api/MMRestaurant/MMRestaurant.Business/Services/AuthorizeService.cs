namespace MMRestaurant.Business.Services
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Net.Mail;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.IdentityModel.Tokens;
    using MMRestaurant.Domain.Entities;
    using MMRestaurant.Domain.Configuration;
    using MMRestaurant.Domain.Constants.Exceptions;
    using MMRestaurant.Domain.Models.Auth;
    using MMRestaurant.Domain.Contracts.Services;

    public class AuthorizeService : IAuthorizeService
    {
        private readonly AuthOptions _options;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AuthorizeService(
            AuthOptions options,
            SignInManager<User> signInManager,
            UserManager<User> userManager)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<AuthorizeResponse> AuthorizeAsync(AuthorizeRequest request)
        {
            //validating email
            var email = request.Email;
            if (email == null)
            {
                throw new ArgumentException(InvalidInputErrorMessages.MissingEmailError);
            }

            try
            {
                var validEmail = new MailAddress(email).Host.Contains(".");
            }
            catch (Exception)
            {
                throw new ArgumentException(InvalidInputErrorMessages.InvalidEmailError);
            }

            //validating password
            var password = request.Password;
            if (password == null)
            {
                throw new ArgumentException(InvalidInputErrorMessages.PasswordMissing);
            }

            //find user in db
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new ArgumentException(InvalidInputErrorMessages.LoginError);
            }

            var signInResult = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);
            if (!signInResult.Succeeded)
            {
                throw new ArgumentException(InvalidInputErrorMessages.LoginError);
            }

            //issuing token
            var response = new AuthorizeResponse
            {
                AccessToken = await GetAccessTokenAsync(user),
                TokenType = "Bearer",
                ExpiresIn = _options.TokenLifetimeSeconds
            };

            return response;
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

            if (roles.Any())
            {
                claims.Add(new Claim("role", roles.First()));
            }

            return claims;
        }
    }
}
