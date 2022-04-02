namespace MMRestaurant.Domain.Constants.Exceptions
{
    public class InvalidInputErrorMessages
    {
        public const string NameMissing = "Name is required";
        public const string InvalidNameLength = "Name is required and must not exceed 100 characters";

        public const string InvalidEmailLength = "Email is required and must not exceed 255 characters";
        public const string InvalidEmailError = "Invalid email address";
        public const string MissingEmailError = "Email address is required";

        public const string PasswordMissing = "Password is required";
        public const string InvalidPasswordLength = "Password must be at least 8 characters";

        public const string LoginError = "A user with the provided email address and password was not found";
        public const string RoleMissing = "A role must be selected";

        public const string InvalidIdForDelete = "Admin cannot delete their own account";
        public const string InvalidDescriptionLength = "The product description must not exceed 500 characters";
        public const string CategoryMissing = "Selecting a category is required";
        public const string PriceMissing = "Price is required";
    }
}
