namespace MMRestaurant.Domain.Models.Auth
{
    using System.ComponentModel.DataAnnotations;

    public class AuthorizeRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
