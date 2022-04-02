namespace MMRestaurant.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;
    using MMRestaurant.Domain.Constants.Exceptions;

    public class EditSelfModel
    {
        [MaxLength(100, ErrorMessage = InvalidInputErrorMessages.InvalidNameLength)]
        public string? Name { get; set; }

        [MinLength(8, ErrorMessage = InvalidInputErrorMessages.InvalidPasswordLength)]
        public string? Password { get; set; }

        public IFormFile? Picture { get; set; }
    }
}
