namespace MMRestaurant.Business.Services
{
    using MMRestaurant.Domain.Models;

    public interface IUserService
    {
        Task<List<UserModel>> GetAllUsersExcludingAdminAsync(string email);

        Task AddUserAsync(string role, string name, string email, string password);

        Task EditSelfAsync(string userId, EditSelfModel user);

        Task EditUserAsync(string userId, AddOrEditUserModel user);

        Task DeleteUserByIdAsync(string userId);

        Task<UserModel> GetUserModelByIdAsync(string userId);

        Task<GetSelfUserModel> GetSelfByIdAsync(string userId);
    }
}
