namespace MMRestaurant.Domain.Contracts.Services
{
    using MMRestaurant.Domain.Models;
    using MMRestaurant.Domain.Models.Auth;

    public interface IUserService
    {
        Task<ResponseUserModel> GetAllUsersExcludingAdminAsync(string email, int pageStart, int pageSize);

        Task AddUserAsync(string role, string name, string email, string password);

        Task EditSelfAsync(string userId, EditSelfModel user, string picture);

        Task EditUserAsync(string userId, AddOrEditUserModel user);

        Task DeleteUserByIdAsync(string userId);

        Task<UserModel> GetUserModelByIdAsync(string userId);

        Task<GetSelfUserModel> GetSelfByIdAsync(string userId);
    }
}
