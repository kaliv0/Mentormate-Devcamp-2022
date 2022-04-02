namespace CollectionsLinq
{
    using CollectionsLinq.Models;

    public static class Playwright
    {
        public static List<OrderLog> CreateRandomOrderHistory(List<FoodProduct> foodProducts)
        {
            var dataProcessor = new DataProcessor(foodProducts);

            var orderedChicken = dataProcessor.FindProductByName("Chicken");
            var orderedSpinachSoup = dataProcessor.FindProductByName("Spinach");
            var orderedCocaCola = dataProcessor.FindProductByName("Coca");

            var firstOrder = new OrderLog(
                1, new DateTime(2022, 02, 15, 10, 30, 50),
                new List<ProductOrder>
                {
                    new ProductOrder(orderedChicken, 2),
                    new ProductOrder(orderedSpinachSoup, 1),
                });

            var secondOrder = new OrderLog(
                2, new DateTime(2022, 02, 15, 12, 05, 00),
                new List<ProductOrder>
                {
                     new ProductOrder(orderedCocaCola, 1)
                });

            var ordersHistory = new List<OrderLog>() { firstOrder, secondOrder };

            //change coca-cola price and add new order

            dataProcessor.UpdatePrice("Coca-Cola");

            var cocaColaWithNewPrice = dataProcessor.FindProductByName("Coca");
            var thirdOrder = new OrderLog(
                3, new DateTime(2022, 02, 16, 17, 05, 00),
                new List<ProductOrder>
                {
                    new ProductOrder(cocaColaWithNewPrice, 1)
                });

            ordersHistory.Add(thirdOrder);

            //change coca-cola price one more time and add order

            dataProcessor.UpdatePrice("Coca-Cola");

            var cocaColaWithThirdPrice = dataProcessor.FindProductByName("Coca");
            var fourthOrder = new OrderLog(
                4, new DateTime(2022, 02, 23, 09, 15, 00),
                new List<ProductOrder>
                {
                    new ProductOrder(cocaColaWithThirdPrice, 1)
                });

            ordersHistory.Add(fourthOrder);

            return ordersHistory;
        }
    }
}
