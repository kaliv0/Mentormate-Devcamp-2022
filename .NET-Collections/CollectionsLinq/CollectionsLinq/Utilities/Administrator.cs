namespace CollectionsLinq
{
    using CollectionsLinq.Models;

    public class Administrator
    {
        public static List<FoodProduct> PopulateFoodProducts()
        {
            var productList = new List<FoodProduct>()
            {
                    new FoodProduct(
                        1, "Chicken with rice", "meat", null, "fried", new List<string>()
                        { "Chicken meat", "Rice", "Spices" },
                        12.00M, true),

                    new FoodProduct(
                        2, "Pork with cabbage", "meat", null, "boiled", new List<string>()
                        { "Pork meat", "Cabbage", "Spices" },
                        15.00M, true),

                    new FoodProduct(
                        3, "Spinach soup", "vegetables", null, "boiled", new List<string>()
                        { "Spinach", "Cheese", "Spices" },
                        8.00M, true),

                    new FoodProduct(
                        4, "Tomato soup", "vegetables", null, "boiled", new List<string>()
                        { "Tomato",  "Spices" },
                        9.00M, false),
                    new FoodProduct(
                        5, "Coca-Cola", "soft drink", null, "no sugar", new List<string>()
                        { "water",  "magic" },
                        2.00M, false),
                    new FoodProduct(
                        6, "Spaghetti Bolonese", "pasta", null, "boiled", new List<string>()
                        { "Spaghetti", "Tomato sauce",  "Meat" },
                        11.00M, false)
            };

            return productList;
        }       
    }
}
