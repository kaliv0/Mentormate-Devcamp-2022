namespace MMRestaurant.Domain.Entities.Categories
{
    using MMRestaurant.Domain.Entities.Products;
    using System.Collections.Generic;

    public class ProductCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentCategoryId { get; set; }

        public virtual ProductCategory? ParentCategory { get; set; }

        public virtual List<ProductCategory> Subcategories { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
