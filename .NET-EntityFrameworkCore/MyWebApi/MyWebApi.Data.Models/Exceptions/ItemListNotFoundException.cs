namespace MyWebApi.Data.Models.Exceptions
{
    public class ItemListNotFoundException : Exception
    {
        public ItemListNotFoundException(string? message)
            : base(message)
        {
        }
    }
}
