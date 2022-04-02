namespace DeviceManager.Data
{
    using Microsoft.EntityFrameworkCore;
    using DeviceManager.Domain.Entities;

    public class DbInitializer
    {
        private readonly DeviceManagerDbContext _dbContext;

        public DbInitializer(DeviceManagerDbContext dbContext)
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
            await SeedDevicesAsync();
        }

        private async Task SeedDevicesAsync()
        {
            if (await _dbContext.Devices.AnyAsync())
            {
                return;
            }

            var devices = new List<Device>
            {
                new Device
                {
                    Name = "Redmi Note",
                    Manufacturer = "Xiomi",
                    Model = "11 Pro",
                    ReleaseDate = new DateTime(2021, 06, 01),
                    DateTaken = new DateTime(2021, 07, 23)
                },

                new Device
                {
                    Name = "ThnikPad",
                    Manufacturer = "Lenovo",
                    Model = "T450",
                    ReleaseDate = new DateTime(2015, 01, 01),
                    DateTaken = new DateTime(2019, 09, 03)
                },

                new Device
                {
                    Name = "Galaxy Tab",
                    Manufacturer = "Samsung",
                    Model = "C7",
                    ReleaseDate = new DateTime(2021, 08, 15),
                },
            };

            _dbContext.Devices.AddRange(devices);
            await _dbContext.SaveChangesAsync();
        }
    }
}
