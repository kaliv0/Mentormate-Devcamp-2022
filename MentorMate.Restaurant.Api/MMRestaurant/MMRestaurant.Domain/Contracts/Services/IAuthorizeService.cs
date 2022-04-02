namespace MMRestaurant.Domain.Contracts.Services
{
    using MMRestaurant.Domain.Models.Auth;
    using System.Threading.Tasks;

    public interface IAuthorizeService
    {
        Task<AuthorizeResponse> AuthorizeAsync(AuthorizeRequest request);
    }
}
