namespace MentorMate.Payments.App
{
    using System.Text;
    using MentorMate.Payment.Business.Models;

    public static class PaymentsIO
    {
        public static void PromptUser(ICollection<Product> products)
        {
            Console.WriteLine("Select a product from the following list and enter its number:");

            var sb = new StringBuilder();
            foreach (var product in products)
            {
                sb.AppendLine($"{product.Id}. {product.Name} - {product.Description} - ${product.Price}");
            }

            var result = sb.ToString();
            Console.Write(result);
        }

        public static int ReadInput(int rangeStart, int rangeEnd)
        {
            var isValid = int.TryParse(Console.ReadLine(), out int number);

            if (!isValid ||
               (isValid && (number < rangeStart || number > rangeEnd)))
            {
                Console.WriteLine("Please enter valid number!");
                number = ReadInput(rangeStart, rangeEnd);
            }
            return number;
        }

        public static int ReadPaymentProvider()
        {
            Console.WriteLine("Select payment provider from the following list and enter its number:");
            Console.WriteLine("1. PayPal");
            Console.WriteLine("2. Stripe");

            var providerNumber = PaymentsIO.ReadInput(1, 2);

            return providerNumber;
        }
    }
}
