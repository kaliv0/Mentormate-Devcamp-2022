namespace MMRestaurant.Domain.Models.Categories
{
    public class CategoryModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<CategoryModel> Subcategories { get; set; }
    }
}
