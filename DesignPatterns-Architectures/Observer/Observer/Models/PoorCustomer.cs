namespace Observer.Models
{
    using Observer.Contracts;

    public class PoorCustomer : IObserver
    {
        public PoorCustomer(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public void Update(decimal propertyTax, decimal ttpTax)
        {
            if (propertyTax >= 600 || ttpTax >= 240)
            {
                Console.WriteLine($"{this.Name} reacted.");
            }
        }
    }
}
