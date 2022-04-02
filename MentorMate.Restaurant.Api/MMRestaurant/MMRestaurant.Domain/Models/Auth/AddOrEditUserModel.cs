namespace MMRestaurant.Domain.Models
{
    using MMRestaurant.Domain.Constants.Exceptions;
    using System.ComponentModel.DataAnnotations;

    public class AddOrEditUserModel
    {
        [Required(ErrorMessage = InvalidInputErrorMessages.NameMissing)]
        [MaxLength(100, ErrorMessage = InvalidInputErrorMessages.InvalidNameLength)]
        public string Name { get; set; }

        [EmailAddress]
        [MaxLength(255, ErrorMessage = InvalidInputErrorMessages.InvalidEmailLength)]
        public string Email { get; set; }

        [Required(ErrorMessage = InvalidInputErrorMessages.PasswordMissing)]
        [MinLength(8, ErrorMessage = InvalidInputErrorMessages.InvalidPasswordLength)]
        public string Password { get; set; }

        [Required(ErrorMessage = InvalidInputErrorMessages.RoleMissing)]
        public string Role { get; set; }
    }
}
