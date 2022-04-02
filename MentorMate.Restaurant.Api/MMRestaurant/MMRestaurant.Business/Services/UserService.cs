namespace MMRestaurant.Business.Services
{
    using System.Threading.Tasks;
    using MMRestaurant.Domain.Contracts.Repositories;
    using MMRestaurant.Domain.Contracts.Services;
    using MMRestaurant.Domain.Models;
    using MMRestaurant.Domain.Models.Auth;

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddUserAsync(string role, string name, string email, string password)
        {
            await _userRepository.ValidateUniqueEmailAsync(email);
            await _userRepository.ValidateRoleAsync(role);

            await _userRepository.AddUserAsync(role, name, email, password);
        }

        public async Task EditSelfAsync(string userId, EditSelfModel user, string picture)
        {
            await _userRepository.EditSelfAsync(userId, user, picture);
        }

        public async Task EditUserAsync(string userId, AddOrEditUserModel user)
        {
            await _userRepository.ValidateUniqueEmailAsync(user.Email);
            await _userRepository.ValidateRoleAsync(user.Role);

            await _userRepository.EditUserAsync(userId, user);
        }

        public async Task<ResponseUserModel> GetAllUsersExcludingAdminAsync(
            string email, int pageStart, int pageSize)
        {
            var users = await _userRepository.GetAllUsersExcludingAdminAsync(email);
            var totalCount = users.Count;

            users = users.Skip(pageSize * (pageStart - 1)).Take(pageSize).ToList();

            //create response model list
            var response = new ResponseUserModel
            {
                Page = pageStart,
                PageSize = pageSize,
                TotalCount = totalCount,
                UserModels = users
            };

            return response;
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
