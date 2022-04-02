namespace Strategy.Models.Strategies
{
    using Strategy.Contracts;

    public class NewYearStrategy : IStrategy
    {
        public decimal Compute(decimal price)
        {
            return price * 0.01M;
        }
    }
}
