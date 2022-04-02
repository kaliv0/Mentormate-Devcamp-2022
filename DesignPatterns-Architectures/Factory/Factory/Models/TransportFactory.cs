namespace Factory.Models
{
    using Factory.Models.TransportVehicles;

    public class TransportFactory
    {
        public ITransport CreateTransport(string transportType)
        {
            switch (transportType)
            {
                case "land":
                    return new Truck();
                case "air":
                    return new Airplane();
                case "sea":
                    return new Ferry();
                default:
                    throw new Exception("No such transport!");
            }
        }
    }
}
