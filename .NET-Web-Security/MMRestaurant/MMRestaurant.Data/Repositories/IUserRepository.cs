namespace MMRestaurant.Data.Repositories
{
    using MMRestaurant.Data.Entities;
    using MMRestaurant.Domain.Models;

    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllUsersExcludingAdminAsync(string email);

        Task AddUserAsync(string role, string name, string email, string password);

        Task EditSelfAsync(string userId, EditSelfModel user);

        Task EditUserAsync(string userId, AddOrEditUserModel user);

        Task DeleteUserByIdAsync(string userId);

        Task<UserModel> GetUserModelByIdAsync(string userId);

        Task<User> GetUserByIdAsync(string userId);

        Task ValidateUniqueEmail(string email);

        Task ValidateRole(string role);
    }
}
