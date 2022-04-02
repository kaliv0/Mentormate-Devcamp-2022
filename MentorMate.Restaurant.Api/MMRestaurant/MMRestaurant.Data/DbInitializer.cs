namespace MMRestaurant.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using MMRestaurant.Domain.Constants;
    using MMRestaurant.Domain.Entities;
    using MMRestaurant.Domain.Entities.Tables;
    using MMRestaurant.Domain.Entities.Orders;
    using MMRestaurant.Domain.Constants.Enums;

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
            await SeedTablesAsync();
            await SeedOrderStatusesAsync();
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

            await _context.AddRangeAsync(
                new RoleAction { ActionType = "Edit" },
                new RoleAction { ActionType = "Delete" });

            await _context.SaveChangesAsync();
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

            await _context.SaveChangesAsync();
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

            await _context.SaveChangesAsync();
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
                Name = "Test Testov",
            };

            await _userManager.CreateAsync(adminUser, "Admin@11");
            await _userManager.AddToRoleAsync(adminUser, UserRoles.Admin);

            // helper data for testing API
            var secondAdminUser = new User
            {
                Email = "admin2@mentormate.com",
                UserName = "UnicornAdmin",
                Name = "Peter Peterson",
            };

            await _userManager.CreateAsync(secondAdminUser, "Admin@22");
            await _userManager.AddToRoleAsync(secondAdminUser, UserRoles.Admin);

            var waiterUser = new User
            {
                Email = "waiter@mentormate.com",
                UserName = "FunkyWaiter",
                Name = "Nestor Nestorinov",
            };

            await _userManager.CreateAsync(waiterUser, "Waiter@22");
            await _userManager.AddToRoleAsync(waiterUser, UserRoles.Waiter);

            await _context.SaveChangesAsync();
        }

        private async Task SeedTablesAsync()
        {
            if (await _context.Tables.AnyAsync())
            {
                return;
            }

            await _context.AddRangeAsync(
               new Table { TableNumber = 1, Capacity = 2 },
               new Table { TableNumber = 2, Capacity = 2 },
               new Table { TableNumber = 3, Capacity = 2 },
               new Table { TableNumber = 4, Capacity = 4 },
               new Table { TableNumber = 5, Capacity = 4 },
               new Table { TableNumber = 6, Capacity = 4 },
               new Table { TableNumber = 7, Capacity = 6 },
               new Table { TableNumber = 8, Capacity = 8 },
               new Table { TableNumber = 9, Capacity = 10 },
               new Table { TableNumber = 10, Capacity = 12 });

            await _context.SaveChangesAsync();
        }

        private async Task SeedOrderStatusesAsync()
        {
            if (await _context.OrderStatuses.AnyAsync())
            {
                return;
            }

            var orderStatuses = new List<OrderStatus>
            {
                new OrderStatus { Title = OrderStatusCode.Active},
                new OrderStatus { Title = OrderStatusCode.Complete }
            };

            _context.OrderStatuses.AddRange(orderStatuses);
            await _context.SaveChangesAsync();
        }
    }
}
