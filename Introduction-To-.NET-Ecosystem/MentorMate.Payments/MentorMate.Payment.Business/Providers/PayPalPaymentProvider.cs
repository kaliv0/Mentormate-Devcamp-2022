namespace MentorMate.Payment.Business.Providers
{
    using MentorMate.Payment.Business.Models;

    public class PayPalPaymentProvider : IPaymentProvider
    {
        private const string PROVIDER_NAME = "PayPal";

        public bool ProcessPayment(Payment payment)
        {
            if (payment != null)
            {
                Console.WriteLine($"Provider name: {PROVIDER_NAME}");
                Console.WriteLine($"Payment amount: ${payment.Amount}");
                Console.WriteLine($"Reason for payment: {payment.Description}");

                return true;
            }

            return false;
        }
    }
}
