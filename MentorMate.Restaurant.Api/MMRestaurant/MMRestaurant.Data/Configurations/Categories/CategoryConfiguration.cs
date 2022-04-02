namespace MMRestaurant.Data.Configurations.Categories
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MMRestaurant.Domain.Entities.Categories;

    public class CategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategories");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(100);

            builder
                .HasOne(c => c.ParentCategory)
                .WithMany(pc => pc.Subcategories)
                .HasForeignKey(c => c.ParentCategoryId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
