namespace MyWebApi.Data.Models.Exceptions
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string? message)
            : base(message)
        {
        }
    }
}
