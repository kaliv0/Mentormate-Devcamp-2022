namespace MyWebApi.Data
{
    using Microsoft.EntityFrameworkCore;
    using MyWebApi.Data.Models.Entities;
    using MyWebApi.Data.Models.Entities.Enums;

    public class DbInitializer
    {
        private readonly MyWebApiDbContext _dbContext;

        public DbInitializer(MyWebApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task InitializeAsync()
        {
            await ApplyMigrationsAsync();
            await SeedAsync();
        }

        private async Task ApplyMigrationsAsync()
        {
            var pendingMigrations = await _dbContext.Database.GetPendingMigrationsAsync();

            if (pendingMigrations.Any())
            {
                await _dbContext.Database.MigrateAsync();
            }
        }

        private async Task SeedAsync()
        {
            await SeedPrioritiesAsync();
            await SeedStatusesAsync();
            await SeedToDoItemsAsync();

        }

        private async Task SeedToDoItemsAsync()
        {
            if (await _dbContext.ToDoItems.AnyAsync())
            {
                return;
            }

            var toDoItems = new List<ToDoItem>
            {
                new ToDoItem
                {
                   Title = "DRY",
                   Description = "Don't repeat yourself",
                   Priority = await _dbContext.Priorities.FirstOrDefaultAsync(p => p.Id == 3),
                   Status = await _dbContext.Statuses.FirstOrDefaultAsync(p => p.Id == 1)
                },

                new ToDoItem
                {
                    Title = "TTCO",
                    Description = "Think twice, code once",
                    Priority = await _dbContext.Priorities.FirstOrDefaultAsync(p => p.Id == 1),
                    Status = await _dbContext.Statuses.FirstOrDefaultAsync(p => p.Id == 2),
                },
            };

            _dbContext.ToDoItems.AddRange(toDoItems);
            await _dbContext.SaveChangesAsync();
        }

        private async Task SeedPrioritiesAsync()
        {
            if (await _dbContext.Priorities.AnyAsync())
            {
                return;
            }

            var priorities = new List<Priority>
            {
                new Priority { Title = PriorityLevel.Low },
                new Priority { Title = PriorityLevel.Medium },
                new Priority { Title = PriorityLevel.High },
            };

            _dbContext.Priorities.AddRange(priorities);
            await _dbContext.SaveChangesAsync();
        }

        private async Task SeedStatusesAsync()
        {
            if (await _dbContext.Statuses.AnyAsync())
            {
                return;
            }

            var statuses = new List<Status>
            {
                new Status { Title = StatusCode.Pending},
                new Status { Title = StatusCode.InProgress },
                new Status { Title = StatusCode.Complete },
            };

            _dbContext.Statuses.AddRange(statuses);
            await _dbContext.SaveChangesAsync();
        }
    }
}
