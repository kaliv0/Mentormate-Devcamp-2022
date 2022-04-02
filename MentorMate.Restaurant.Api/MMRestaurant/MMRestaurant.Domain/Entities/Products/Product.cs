namespace MMRestaurant.Domain.Entities.Products
{
    using MMRestaurant.Domain.Entities.Categories;
    using MMRestaurant.Domain.Entities.Orders;

    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int ProductCategoryId { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

        public virtual List<OrderProduct> OrderProducts { get; set; }
    }
}
