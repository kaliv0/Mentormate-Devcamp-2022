namespace MMRestaurant.Domain.Models
{
    using MMRestaurant.Domain.Constants.Exceptions;
    using System.ComponentModel.DataAnnotations;

    public class EditSelfModel
    {
        [MaxLength(100, ErrorMessage = InvalidInputErrorMessages.InvalidNameLength)]
        public string? Name { get; set; }

        [MinLength(8, ErrorMessage = InvalidInputErrorMessages.InvalidPasswordLength)]
        public string? Password { get; set; }

        public string? Picture { get; set; }
    }
}
