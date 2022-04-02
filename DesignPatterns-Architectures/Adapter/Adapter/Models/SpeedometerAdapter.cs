namespace Adapter.Models
{
    using Adapter.Contracts;

    public class SpeedometerAdapter : IAmericanSpeedometer
    {
        private const double MilesMultiplier = 1.60934;

        private readonly EuropeanSpeedometer _europeanSpeedometer;

        public SpeedometerAdapter(EuropeanSpeedometer europeanSpeedometer)
        {
            _europeanSpeedometer = europeanSpeedometer;
        }

        public void LogSpeed(double speed)
        {
            var kilometers = speed * MilesMultiplier;
            _europeanSpeedometer.LogSpeedInKms(kilometers);
        }
    }
}
