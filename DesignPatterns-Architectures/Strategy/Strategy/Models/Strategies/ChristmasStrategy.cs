namespace Strategy.Models.Strategies
{
    using Strategy.Contracts;

    public class ChristmasStrategy : IStrategy
    {
        public decimal Compute(decimal price)
        {
            return price * 0.05M;
        }
    }
}
