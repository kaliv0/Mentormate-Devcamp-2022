namespace MentorMate.Payment.Business.Providers
{
    using MentorMate.Payment.Business.Models;

    public interface IPaymentProvider
    {
        bool ProcessPayment(Payment payment);
    }
}
