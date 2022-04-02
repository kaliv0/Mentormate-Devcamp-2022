namespace Adapter.Models
{
    using Adapter.Contracts;

    public class AmericanSpeedometer : IAmericanSpeedometer
    {
        public void LogSpeed(double speed)
        {
            Console.WriteLine($"Speed in miles {speed:F2}");
        }
    }
}
