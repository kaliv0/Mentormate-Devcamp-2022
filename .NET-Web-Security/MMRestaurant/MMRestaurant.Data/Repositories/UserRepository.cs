namespace MMRestaurant.Data.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using MMRestaurant.Data.Entities;
    using MMRestaurant.Domain.Constants.Exceptions;
    using MMRestaurant.Domain.Models;

    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private UserManager<User> _userManager;
        private RoleManager<Role> _roleManager;

        public UserRepository(
            ApplicationDbContext dbContext, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task AddUserAsync(string role, string name, string email, string password)
        {
            //add new user
            var newUser = new User
            {
                Email = email,
                UserName = email,
                Name = name,
            };

            await _userManager.CreateAsync(newUser, password);
            await _userManager.AddToRoleAsync(newUser, role);
        }

        public async Task EditSelfAsync(string userId, EditSelfModel user)
        {
            //get user form db
            var userToEdit = await this.GetUserByIdAsync(userId);

            //change password
            await _userManager.RemovePasswordAsync(userToEdit);
            await _userManager.AddPasswordAsync(userToEdit, user.Password);

            userToEdit = await this.GetUserByIdAsync(userId);

            //change name and picture
            userToEdit.Name = user.Name;
            userToEdit.Picture = user.Picture;

            await _userManager.UpdateAsync(userToEdit);
        }

        public async Task EditUserAsync(string userId, AddOrEditUserModel user)
        {
            //get user to edit
            var userToEdit = await this.GetUserByIdAsync(userId);

            //change password
            await _userManager.RemovePasswordAsync(userToEdit);
            await _userManager.AddPasswordAsync(userToEdit, user.Password);

            //change role
            userToEdit = await this.GetUserByIdAsync(userId);
            var userRoles = await _userManager.GetRolesAsync(userToEdit);
            await _userManager.RemoveFromRoleAsync(userToEdit, userRoles[0]);
            await _userManager.AddToRoleAsync(userToEdit, user.Role);

            //change name and email
            userToEdit = await this.GetUserByIdAsync(userId);
            userToEdit.Name = user.Name;
            userToEdit.Email = user.Email;

            await _userManager.UpdateAsync(userToEdit);
        }

        public async Task<List<UserModel>> GetAllUsersExcludingAdminAsync(string email)
        {
            //get all user with role actions
            var usersWithRoles = await (
                 from u in _dbContext.Users
                 .Where(u => u.Email != email)
                 select new UserModel
                 {
                     Name = u.Name,
                     Email = u.Email,
                     Actions = (
                         from ur in _dbContext.UserRoles
                         join r in _dbContext.Roles on ur.RoleId equals r.Id
                         join ar in _dbContext.RoleRoleActions on r.Id equals ar.RoleId
                         join a in _dbContext.RoleActions on ar.RoleActionId equals a.Id
                         where ur.UserId == u.Id
                         select a.ActionType)
                     .ToList()
                 }).ToListAsync();

            if (!usersWithRoles.Any())
            {
                throw new ArgumentException(RepositoryErrorMessages.NoUsersFound);
            }

            return usersWithRoles;
        }

        public async Task DeleteUserByIdAsync(string userId)
        {
            var userToDelete = await this.GetUserByIdAsync(userId);
            await _userManager.DeleteAsync(userToDelete);
        }

        public async Task<UserModel> GetUserModelByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new ArgumentException();
            }

            var userInDb = await _dbContext.Users
                 .FirstOrDefaultAsync(u => u.Id == userId);

            var userModel = new UserModel
            {
                Name = userInDb.Name,
                Email = userInDb.Email,
                Actions = (
                       from ur in _dbContext.UserRoles
                       join r in _dbContext.Roles on ur.RoleId equals r.Id
                       join ar in _dbContext.RoleRoleActions on r.Id equals ar.RoleId
                       join a in _dbContext.RoleActions on ar.RoleActionId equals a.Id
                       where ur.UserId == userInDb.Id
                       select a.ActionType)
                   .ToList()
            };

            return userModel;
        }

        public async Task<User> GetUserByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new ArgumentException(RepositoryErrorMessages.NoUserFound);
            }

            return user;
        }

        public async Task ValidateUniqueEmail(string email)
        {
            var userInDb = await _userManager.FindByEmailAsync(email);
            if (userInDb != null)
            {
                throw new Exception(RepositoryErrorMessages.DuplicatedEmail);
            }
        }

        public async Task ValidateRole(string role)
        {
            var isRoleInDb = await _roleManager.RoleExistsAsync(role);
            if (!isRoleInDb)
            {
                throw new Exception(RepositoryErrorMessages.InvalidRole);
            }
        }
    }
}
