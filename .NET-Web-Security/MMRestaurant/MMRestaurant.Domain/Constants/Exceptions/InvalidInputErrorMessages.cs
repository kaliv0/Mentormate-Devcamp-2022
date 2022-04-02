namespace MMRestaurant.Domain.Constants.Exceptions
{
    public class InvalidInputErrorMessages
    {
        public const string NameMissing = "Name is required";
        public const string InvalidNameLength = "Name is required and must not exceed 100 characters";
        public const string InvalidEmailLength = "Email is required and must not exceed 255 characters";
        public const string PasswordMissing = "Password is required";
        public const string InvalidPasswordLength = "Password must be at least 8 characters";
        public const string RoleMissing = "A role must be selected";
        public const string InvalidIdForDelete = "Admin cannot delete their own account";
    }
}
