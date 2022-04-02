namespace MentorMate.Payment.Business.Models
{
    public class Payment
    {
        public Payment(decimal amount, string description)
        {
            this.Amount = amount;
            this.Description = description;
        }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}
