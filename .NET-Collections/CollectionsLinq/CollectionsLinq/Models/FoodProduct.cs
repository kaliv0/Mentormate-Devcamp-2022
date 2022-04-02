namespace CollectionsLinq.Models
{
    public class FoodProduct
    {
        public FoodProduct(
            int id, string name, string type, string pictureUrl,
            string description, ICollection<string> ingredients,
            decimal price, bool isEnabled)
        {
            this.Id = id;
            this.Name = name;
            this.Type = type;
            this.PictureUrl = pictureUrl;
            this.Description = description;
            this.Ingredients = ingredients;
            this.Price = price;
            this.IsEnabled = isEnabled;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string PictureUrl { get; set; }

        public string Description { get; set; }

        public ICollection<string> Ingredients { get; set; }

        public decimal Price { get; set; }

        public bool IsEnabled { get; set; }
    }
}
