namespace Strategy.Models.Strategies
{
    using Strategy.Contracts;

    public class RestStrategy : IStrategy
    {
        public decimal Compute(decimal price)
        {
            return 0;
        }
    }
}
