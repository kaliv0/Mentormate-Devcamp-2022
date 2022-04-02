namespace MMRestaurant.Business.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MMRestaurant.Data.Repositories;
    using MMRestaurant.Domain.Models;

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddUserAsync(string role, string name, string email, string password)
        {
            await _userRepository.ValidateUniqueEmail(email);
            await _userRepository.ValidateRole(role);

            await _userRepository.AddUserAsync(role, name, email, password);
        }

        public async Task EditSelfAsync(string userId, EditSelfModel user)
        {
            await _userRepository.EditSelfAsync(userId, user);
        }

        public async Task EditUserAsync(string userId, AddOrEditUserModel user)
        {
            await _userRepository.ValidateUniqueEmail(user.Email);
            await _userRepository.ValidateRole(user.Role);

            await _userRepository.EditUserAsync(userId, user);
        }

        public async Task<List<UserModel>> GetAllUsersExcludingAdminAsync(string email)
        {
            return await _userRepository.GetAllUsersExcludingAdminAsync(email);
        }

        public async Task DeleteUserByIdAsync(string userId)
        {
            await _userRepository.DeleteUserByIdAsync(userId);
        }

        public async Task<UserModel> GetUserModelByIdAsync(string userId)
        {
            return await _userRepository.GetUserModelByIdAsync(userId);
        }

        public async Task<GetSelfUserModel> GetSelfByIdAsync(string userId)
        {
            var userInDb = await _userRepository.GetUserByIdAsync(userId);

            var userModel = new GetSelfUserModel
            {
                Id = userInDb.Id,
                Name = userInDb.Name,
                Email = userInDb.Email,
                Picture = userInDb.Picture
            };

            return userModel;
        }
    }
}
