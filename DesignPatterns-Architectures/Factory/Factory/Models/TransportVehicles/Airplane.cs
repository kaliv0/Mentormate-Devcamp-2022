namespace Factory.Models.TransportVehicles
{
    public class Airplane : ITransport
    {
        public Airplane()
        {
            Console.WriteLine("New airplane is created.");
        }

        public void StartEngine()
        {
            Console.WriteLine("Airplane is flying.");
        }
    }
}
