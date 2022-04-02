using MMRestaurant.Domain.Constants;
using MMRestaurant.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MMRestaurant.Data
{
    public class DbInitializer
    {
        private readonly ApplicationDbContext _context;
        private UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public DbInitializer(
            ApplicationDbContext context, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task InitializeAsync()
        {
            await ApplyMigrationsAsync();
            await SeedRoleActionsAsync();
            await SeedRolesAsync();
            await SeedRoleRoleActionsAsync();
            await SeedUsersAsync();
        }

        private async Task ApplyMigrationsAsync()
        {
            var pendingMigrations = await _context.Database.GetPendingMigrationsAsync();

            if (pendingMigrations.Any())
            {
                await _context.Database.MigrateAsync();
            }
        }

        private async Task SeedRoleActionsAsync()
        {
            if (await _context.RoleActions.AnyAsync())
            {
                return;
            }

            //await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            await _context.AddRangeAsync(
                new RoleAction { ActionType = "Edit" },
                new RoleAction { ActionType = "Delete" });
        }

        private async Task SeedRolesAsync()
        {
            if (await _context.Roles.AnyAsync())
            {
                return;
            }

            var roleAdmin = new Role(UserRoles.Admin);
            await _roleManager.CreateAsync(roleAdmin);

            var roleWaiter = new Role(UserRoles.Waiter);
            await _roleManager.CreateAsync(roleWaiter);
        }
        private async Task SeedRoleRoleActionsAsync()
        {
            if (await _context.RoleRoleActions.AnyAsync())
            {
                return;
            }

            var roleEdit = new RoleRoleAction();
            roleEdit.RoleActionId = _context.RoleActions
                .Where(r => r.ActionType == "Edit")
                .Select(r => r.Id).FirstOrDefault();

            roleEdit.RoleId = _context.Roles
                .Where(r => r.RoleName == "Admin")
                .Select(r => r.Id).FirstOrDefault();

            var roleDelete = new RoleRoleAction();
            roleDelete.RoleActionId = _context.RoleActions
                .Where(r => r.ActionType == "Delete")
                .Select(r => r.Id).FirstOrDefault();

            roleDelete.RoleId = _context.Roles
                .Where(r => r.RoleName == "Admin")
                .Select(r => r.Id).FirstOrDefault();


            await _context.AddRangeAsync(
                roleEdit,
                roleDelete);
        }


        private async Task SeedUsersAsync()
        {
            if (await _context.Users.AnyAsync())
            {
                return;
            }

            var adminUser = new User
            {
                Email = "admin@mentormate.com",
                UserName = "RootAdmin",
                Name = "Test",
            };

            await _userManager.CreateAsync(adminUser, "Admin@11");
            await _userManager.AddToRoleAsync(adminUser, UserRoles.Admin);

            // helper data for testing API
            var secondAdminUser = new User
            {
                Email = "admin2@mentormate.com",
                UserName = "UnicornAdmin",
                Name = "Peter",
            };

            await _userManager.CreateAsync(secondAdminUser, "Admin@22");
            await _userManager.AddToRoleAsync(secondAdminUser, UserRoles.Admin);

            var waiterUser = new User
            {
                Email = "waiter@mentormate.com",
                UserName = "FunkyWaiter",
                Name = "Nestor",
            };

            await _userManager.CreateAsync(waiterUser, "Waiter@22");
            await _userManager.AddToRoleAsync(waiterUser, UserRoles.Waiter);
        }
    }
}
