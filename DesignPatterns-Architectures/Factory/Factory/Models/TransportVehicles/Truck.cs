namespace Factory.Models.TransportVehicles
{
    public class Truck : ITransport
    {
        public Truck()
        {
            Console.WriteLine("New truck is created.");
        }

        public void StartEngine()
        {
            Console.WriteLine("Truck is driving.");
        }
    }
}
