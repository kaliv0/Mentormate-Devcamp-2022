namespace Factory.Models.TransportVehicles
{
    public class Ferry : ITransport
    {
        public Ferry()
        {
            Console.WriteLine("New ferry is created.");
        }

        public void StartEngine()
        {
            Console.WriteLine("Ferry is sailing.");
        }
    }
}
