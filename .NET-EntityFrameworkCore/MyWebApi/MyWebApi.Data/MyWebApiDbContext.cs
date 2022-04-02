namespace MyWebApi.Data
{
    using Microsoft.EntityFrameworkCore;
    using MyWebApi.Data.Configurations;
    using MyWebApi.Data.Models.Entities;

    public class MyWebApiDbContext : DbContext
    {
        public MyWebApiDbContext()
            : base()
        {
        }

        public MyWebApiDbContext(DbContextOptions<MyWebApiDbContext> options)
            : base(options)
        {
        }

        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ToDoItemConfiguration());
            modelBuilder.ApplyConfiguration(new PriorityConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());
        }
    }
}
