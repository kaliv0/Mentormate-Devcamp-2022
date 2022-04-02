namespace Strategy.Models.Strategies
{
    using Strategy.Contracts;

    public class EasterStrategy : IStrategy
    {
        public decimal Compute(decimal price)
        {
            return price * 0.03M;
        }
    }
}
