namespace Strategy.Models
{
    using Strategy.Models.Strategies;

    public class DiscountCalculator
    {
        private Context _context;

        public DiscountCalculator()
        {
            _context = new Context();
        }

        public decimal ComputeDiscount(string holiday, decimal price)
        {
            if (price >= 100)
            {
                if (holiday == "Christmas")
                {
                    _context.SetStrategy(new ChristmasStrategy());
                }
                else if (holiday == "Easter")
                {
                    _context.SetStrategy(new EasterStrategy());
                }
                else if (holiday == "New Year")
                {
                    _context.SetStrategy(new NewYearStrategy());
                }
                else
                {
                    _context.SetStrategy(new RestStrategy());
                }
            }
            else
            {
                _context.SetStrategy(new RestStrategy());
            }

            return _context.ComputeDiscount(price);
        }
    }
}
