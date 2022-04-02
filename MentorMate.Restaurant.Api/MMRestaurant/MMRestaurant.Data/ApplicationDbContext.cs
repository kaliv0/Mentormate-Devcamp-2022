namespace MMRestaurant.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using MMRestaurant.Data.Configurations.Auth;
    using MMRestaurant.Data.Configurations.Categories;
    using MMRestaurant.Data.Configurations.Orders;
    using MMRestaurant.Data.Configurations.Products;
    using MMRestaurant.Data.Configurations.Tables;
    using MMRestaurant.Domain.Entities;
    using MMRestaurant.Domain.Entities.Categories;
    using MMRestaurant.Domain.Entities.Orders;
    using MMRestaurant.Domain.Entities.Products;
    using MMRestaurant.Domain.Entities.Tables;

    public class ApplicationDbContext : IdentityDbContext<User, Role, string>
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<RoleAction> RoleActions { get; set; }
        public DbSet<RoleRoleAction> RoleRoleActions { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RoleRoleActionConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new TableConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new OrderStatusConfiguration());
            builder.ApplyConfiguration(new OrderProductConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
