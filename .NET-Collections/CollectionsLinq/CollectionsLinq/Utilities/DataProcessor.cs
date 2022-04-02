namespace CollectionsLinq
{
    using System.Text;
    using CollectionsLinq.Models;

    public class DataProcessor
    {
        private List<FoodProduct> _foodProducts;
        private List<OrderLog> _ordersHistory;
        private StringBuilder _sb;

        public DataProcessor(List<FoodProduct> foodProducts)
        {
            this._foodProducts = foodProducts;
        }

        public DataProcessor(List<FoodProduct> foodProducts, List<OrderLog> ordersHistory)
        {
            this._foodProducts = foodProducts;
            this._ordersHistory = ordersHistory;
            this._sb = new StringBuilder();
        }

        public FoodProduct FindProductByName(string productName)
        {
            var product = this._foodProducts.FirstOrDefault(p => p.Name.StartsWith(productName));
            return product;
        }

        public void UpdatePrice(string name)
        {
            this._foodProducts.FirstOrDefault(p => p.Name == name).Price++;
        }

        public string GetEnabledProducts()
        {
            var enabledProducts = _foodProducts
                .FindAll(p => p.IsEnabled);

            foreach (var product in enabledProducts)
            {
                _sb.AppendLine($"{product.Name} - isEnabled = {product.IsEnabled }");
            }

            var result = _sb.ToString();
            _sb.Clear();

            return result;
        }

        public string GetProductByPartOfName(string wildcard)
        {
            var products = _foodProducts
                .FindAll(p => p.Name.Contains(wildcard));

            foreach (var product in products)
            {
                _sb.AppendLine($"{product.Name}");
            }

            var result = _sb.ToString();
            _sb.Clear();

            return result;
        }

        public string GetProductsWithRice()
        {
            var products = _foodProducts
                 .FindAll(p => p.Ingredients.Contains("Rice"));

            foreach (var product in products)
            {
                _sb.AppendLine($"{product.Name}");
            }

            var result = _sb.ToString();
            _sb.Clear();

            return result;
        }

        public string SearchOrdersByProduct(string productName)
        {
            var ordersByProduct = _ordersHistory
                .Where(o => o.ProductOrders
                    .Any(po => po.Product.Name == productName));

            foreach (var order in ordersByProduct)
            {
                _sb.AppendLine($"Order number - {order.OrderNumber}, Total price - ${order.TotalPrice:F2}");
            }

            var result = _sb.ToString();
            _sb.Clear();

            return result;
        }

        public string SearchByOrderNumber(int orderNumber)
        {
            _ordersHistory
                .Where(o => o.OrderNumber == orderNumber)
                .Aggregate(_sb, (_sb, o) =>
                 {
                     foreach (var productOrder in o.ProductOrders)
                     {
                         _sb.AppendLine($"{productOrder.Product.Name} - ${productOrder.Product.Price}");
                     }
                     return _sb;
                 });

            var result = _sb.ToString();
            _sb.Clear();

            return result;
        }

        public string SearchOrdersByPeriod(DateOnly startDate, DateOnly endDate)
        {
            _ordersHistory
                .Where(o => DateOnly.FromDateTime(o.Date) >= startDate &&
                           DateOnly.FromDateTime(o.Date) <= endDate)
                .OrderBy(o => o.Date)
                .Aggregate(_sb, (_sb, o) =>
                {
                    foreach (var productOrder in o.ProductOrders)
                    {
                        _sb.AppendLine($"{productOrder.Product.Name} - {o.Date}");
                    }

                    return _sb;
                });

            var result = _sb.ToString();
            _sb.Clear();

            return result;
        }

        public string SearchProductsForLastMonth(DateOnly startDate, DateOnly endDate)
        {
            var allProducts = _ordersHistory
                .Where(o => DateOnly.FromDateTime(o.Date) >= startDate &&
                            DateOnly.FromDateTime(o.Date) <= endDate)
                .SelectMany(o => o.ProductOrders
                        .Select(op => new
                        {
                            op.Product.Name,
                            op.TotalPrice,
                            op.Quantity
                        }))
                .GroupBy(p => p.Name);


            foreach (var orderGroup in allProducts)
            {
                _sb.Append($"Product name: {orderGroup.Key}, ");
                _sb.Append($"Product count: {orderGroup.Sum(p => p.Quantity)}, ");
                _sb.AppendLine($"Total price: {orderGroup.Sum(p => p.TotalPrice)}");
            }

            var result = _sb.ToString();
            _sb.Clear();

            return result;
        }

        public string SearchAverageOrdersForLastMonth(DateOnly startDate, DateOnly endDate)
        {
            var allOrders = _ordersHistory
                 .Where(o => DateOnly.FromDateTime(o.Date) >= startDate &&
                             DateOnly.FromDateTime(o.Date) < endDate)
                 .GroupBy(o => o.Date.Day);

            var totalDays = endDate.ToDateTime(TimeOnly.Parse("12:00 AM")) - startDate.ToDateTime(TimeOnly.Parse("12:00 AM"));
            var ordersTotalCount = allOrders.Select(o => o.Count()).Sum();
            var averageOrderAmount = ordersTotalCount * 1.0 / totalDays.Days;

            return $"Average orders amount per day: {averageOrderAmount:F2}";
        }

        public string GetTotalOrderAmountPerMonth(DateOnly startDate, DateOnly endDate)
        {
            var allOrders = _ordersHistory
                 .Where(o => DateOnly.FromDateTime(o.Date) >= startDate &&
                             DateOnly.FromDateTime(o.Date) < endDate)
                 .GroupBy(o => o.Date.Day);

            foreach (var orderGroup in allOrders)
            {
                _sb.AppendLine($"Day of month: {orderGroup.Key} - Amount of orders: {orderGroup.Count()}");
            }

            var result = _sb.ToString();
            _sb.Clear();

            return result;
        }
    }
}
