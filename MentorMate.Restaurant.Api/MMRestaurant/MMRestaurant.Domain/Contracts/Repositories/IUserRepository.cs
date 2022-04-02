namespace MMRestaurant.Domain.Contracts.Repositories
{
    using MMRestaurant.Domain.Entities;
    using MMRestaurant.Domain.Models;

    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllUsersExcludingAdminAsync(string email);

        Task AddUserAsync(string role, string name, string email, string password);

        Task EditSelfAsync(string userId, EditSelfModel user, string picture);

        Task EditUserAsync(string userId, AddOrEditUserModel user);

        Task DeleteUserByIdAsync(string userId);

        Task<UserModel> GetUserModelByIdAsync(string userId);

        Task<User> GetUserByIdAsync(string userId);

        Task<User> GetUserByEmailAsync(string email);

        Task ValidateUniqueEmailAsync(string email);

        Task ValidateRoleAsync(string role);
    }
}
