namespace Observer.Models
{
    using Observer.Contracts;

    public class RichCustomer : IObserver
    {
        public RichCustomer(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public void Update(decimal propertyTax, decimal ttpTax)
        {
            if (propertyTax >= 750M || ttpTax >= 300)
            {
                Console.WriteLine($"{this.Name} reacted.");
            }
        }
    }
}
