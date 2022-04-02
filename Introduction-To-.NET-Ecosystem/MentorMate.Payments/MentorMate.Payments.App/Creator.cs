namespace MentorMate.Payments.App
{
    using MentorMate.Payment.Business.Models;
    using MentorMate.Payment.Business.Providers;

    public static class Creator
    {
        public static IPaymentProvider createProvider(int providerNumber)
        {
            IPaymentProvider paymentProvider = null;
            if (providerNumber == 1)
            {
                paymentProvider = new PayPalPaymentProvider();
            }
            else if (providerNumber == 2)
            {
                paymentProvider = new StripePaymentProvider();
            }

            return paymentProvider;
        }

        public static Payment createPayment(int productId, ICollection<Product> products)
        {
            var selectedProduct = products.FirstOrDefault(x => x.Id == productId);
            var payment = new Payment(selectedProduct.Price, $"{selectedProduct.Name} - {selectedProduct.Description}");
            return payment;
        }
    }
}
