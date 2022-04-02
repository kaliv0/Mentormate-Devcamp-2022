using Strategy.Models;

var calculator = new DiscountCalculator();

Console.WriteLine("Computing discount for price under $100:");
var discount = calculator.ComputeDiscount("Christmas", 80);
Console.WriteLine(discount);

Console.WriteLine("Computing Christmas discount for price equal to $100:");
discount = calculator.ComputeDiscount("Christmas", 100);
Console.WriteLine(discount);

Console.WriteLine("Computing Easter discount:");
discount = calculator.ComputeDiscount("Easter", 100);
Console.WriteLine(discount);

Console.WriteLine("Computing again discount for price under $100:");
discount = calculator.ComputeDiscount("Christmas", 80);
Console.WriteLine(discount);

Console.WriteLine("Computing New Year discount:");
discount = calculator.ComputeDiscount("New Year", 100);
Console.WriteLine(discount);

Console.WriteLine("Computing Hanukkah discount:");
discount = calculator.ComputeDiscount("Hanukkah", 100);
Console.WriteLine(discount);


