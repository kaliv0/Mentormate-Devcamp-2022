namespace MentorMate.Payment.Business.Services
{
    using MentorMate.Payment.Business.Models;

    public interface IProductService
    {
        ICollection<Product> GetProducts();
    }
}
