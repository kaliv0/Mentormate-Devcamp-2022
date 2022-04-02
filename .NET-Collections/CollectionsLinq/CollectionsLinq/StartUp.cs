using CollectionsLinq;

//populate products list
var foodProducts = Administrator.PopulateFoodProducts();
var ordersHistory = Playwright.CreateRandomOrderHistory(foodProducts);
var dataProcessor = new DataProcessor(foodProducts, ordersHistory);

//------------------------------------------------------------------------------------------
//queries
//1. Food products list - select all enabled products
Console.WriteLine("1. Food products list - select all enabled products");

var enabledProducts = dataProcessor
    .GetEnabledProducts();

Console.WriteLine(enabledProducts);
Console.WriteLine("===============");

//2. Search by part of a product  name ("%to%")

Console.WriteLine("2. Search by part of a product  name");

var matchingProducts = dataProcessor
    .GetProductByPartOfName("to");

Console.WriteLine(matchingProducts);
Console.WriteLine("===============");

//3. Search all products which contain ingredient rice

Console.WriteLine("3. Search all products which contain ingredient rice");

var productsWithRice = dataProcessor
    .GetProductsWithRice();

Console.WriteLine(productsWithRice);
Console.WriteLine("===============");

//4. Search orders by product

Console.WriteLine("4. Search orders by product");

var ordersByProduct = dataProcessor
    .SearchOrdersByProduct("Coca-Cola");

Console.WriteLine(ordersByProduct);
Console.WriteLine("===============");

//5. Search by order number

Console.WriteLine("5. Search by order number");

var ordersByNumber = dataProcessor
    .SearchByOrderNumber(1);

Console.WriteLine(ordersByNumber);
Console.WriteLine("===============");

//6. Search sold products during a period

Console.WriteLine("6. Search sold products during a period");

var ordersByPeriod = dataProcessor
    .SearchOrdersByPeriod(
        new DateOnly(2022, 02, 15),
        new DateOnly(2022, 02, 17));

Console.WriteLine(ordersByPeriod);
Console.WriteLine("===============");

//7. Search sold products for the last month

Console.WriteLine("7. Search sold products for the last month");

var allProducts = dataProcessor
    .SearchProductsForLastMonth(
          new DateOnly(2022, 02, 15),
          new DateOnly(2022, 02, 28));

Console.WriteLine(allProducts);
Console.WriteLine("===============");

//8. Search average orders amount for the last month

Console.WriteLine("8. Search average orders amount for the last month");

var averageOrderAmount = dataProcessor
    .SearchAverageOrdersForLastMonth(
          new DateOnly(2022, 02, 01),
          new DateOnly(2022, 03, 01));

Console.WriteLine($"Average orders amount per day: {averageOrderAmount:F2}");
Console.WriteLine(Environment.NewLine + "===============");

//9. Search total orders amount per day for the last month

Console.WriteLine("9. Search total orders amount per day for the last month");

var totalAmount = dataProcessor
    .GetTotalOrderAmountPerMonth(
          new DateOnly(2022, 02, 01),
          new DateOnly(2022, 03, 01));

Console.WriteLine(totalAmount.ToString());