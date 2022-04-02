namespace Strategy.Models
{
    using Strategy.Contracts;
    using Strategy.Models.Strategies;

    public class Context
    {
        private IStrategy _strategy;

        public Context()
        {
            _strategy = new RestStrategy();
        }

        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public decimal ComputeDiscount(decimal price)
        {
            return _strategy.Compute(price);
        }
    }
}
