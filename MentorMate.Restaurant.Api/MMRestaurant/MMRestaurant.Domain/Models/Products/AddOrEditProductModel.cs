namespace MMRestaurant.Domain.Models.Products
{
    using System.ComponentModel.DataAnnotations;
    using MMRestaurant.Domain.Constants.Exceptions;

    public class AddOrEditProductModel
    {
        [Required(ErrorMessage = InvalidInputErrorMessages.NameMissing)]
        [MaxLength(100, ErrorMessage = InvalidInputErrorMessages.InvalidNameLength)]
        public string Name { get; set; }

        [MaxLength(500, ErrorMessage = InvalidInputErrorMessages.InvalidDescriptionLength)]
        public string Description { get; set; }

        [Required(ErrorMessage = InvalidInputErrorMessages.PriceMissing)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = InvalidInputErrorMessages.CategoryMissing)]
        public int ProductCategoryId { get; set; }
    }
}
