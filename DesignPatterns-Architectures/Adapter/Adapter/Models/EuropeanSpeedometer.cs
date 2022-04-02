namespace Adapter.Models
{
    using Adapter.Contracts;
 
    public class EuropeanSpeedometer : IEuropeanSpeedometer
    {
        public void LogSpeedInKms(double speed)
        {
            Console.WriteLine($"Speed in kilometers {speed:F2}");
        }
    }
}
