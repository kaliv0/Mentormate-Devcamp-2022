namespace Observer.Models
{
    using Observer.Contracts;

    public class Bank : ISubject
    {
        private ICollection<IObserver> _customers;
        private decimal _propertyTax;
        private decimal _ttpTax;

        public Bank()
        {
            _customers = new List<IObserver>();
            _propertyTax = 500M;
            _ttpTax = 200M;

        }

        public void Subscribe(IObserver customer)
        {
            _customers.Add(customer);
            Console.WriteLine("New customer added to list of customer");
        }

        public void Unsubscribe(IObserver customer)
        {
            _customers.Remove(customer);
            Console.WriteLine("Customer removed.");
        }

        public void Notify()
        {
            Console.WriteLine("Bank is notifying subscribed customers about tax price changes");

            foreach (var customer in _customers)
            {
                customer.Update(_propertyTax, _ttpTax);
            }
        }

        public void ChangeTaxes(decimal taxChange)
        {
            Console.WriteLine("=========");
            Console.WriteLine("Bank is raising tax prices.");

            _propertyTax += (_propertyTax * taxChange);
            _ttpTax *= taxChange;

            Thread.Sleep(1000);

            Console.WriteLine($"Tax prices has been raised with {taxChange * 100:F0} percent");
            this.Notify();
        }
    }
}
