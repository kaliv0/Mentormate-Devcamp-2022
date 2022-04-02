namespace MyWebApi.Data.Models.Exceptions
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(string? message)
            : base(message)
        {
        }
    }
}
