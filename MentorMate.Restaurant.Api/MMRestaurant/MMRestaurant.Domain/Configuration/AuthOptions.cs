using System.Text;

namespace MMRestaurant.Domain.Configuration
{
    public class AuthOptions
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string SecurityKey { get; set; }

        public byte[] SecurityKeyAsBytes => Encoding.UTF8.GetBytes(SecurityKey);

        public int TokenLifetimeSeconds { get; set; } = 24 * 60 * 60; // 24 hours
    }
}
