namespace MMRestaurant.Domain.Models.Categories
{
    using System.ComponentModel.DataAnnotations;
    using MMRestaurant.Domain.Constants.Exceptions;

    public class AddOrEditCategoryModel
    {
        [Required(ErrorMessage = InvalidInputErrorMessages.NameMissing)]
        [MaxLength(100, ErrorMessage = InvalidInputErrorMessages.InvalidNameLength)]
        public string Name { get; set; }

        public int? ParentCategoryId { get; set; }
    }
}
