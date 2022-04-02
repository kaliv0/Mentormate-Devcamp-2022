namespace DeviceManager.Data
{
    using Microsoft.EntityFrameworkCore;
    using DeviceManager.Data.Configurations;
    using DeviceManager.Domain.Entities;

    public class DeviceManagerDbContext : DbContext
    {
        public DeviceManagerDbContext()
            : base()
        {
        }

        public DeviceManagerDbContext(DbContextOptions<DeviceManagerDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //needed for creating the initial migration
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(
                        "Server=.;Database=DeviceManager;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        public DbSet<Device> Devices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DeviceConfiguration());
        }
    }
}
