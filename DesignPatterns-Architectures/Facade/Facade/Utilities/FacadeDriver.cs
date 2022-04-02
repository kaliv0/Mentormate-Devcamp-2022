namespace Facade.Utilities
{
    using Facade.Models;

    public class FacadeDriver
    {
        protected Car _car;
        public FacadeDriver(Car car)
        {
            _car = car; 
        }

        public void Start()
        {
            _car.AirflowSensor.EnableSensor();
            _car.FuelPump.StartPump();
            _car.Engine.EnableStarter();
            _car.CoolingPump.StartPump();
        }

        public void Stop()
        {
            _car.FuelPump.StopPump();
            _car.CoolingPump.StopPump();
            _car.AirflowSensor.DisableSensor();
            _car.Engine.DisableStarter();
        }
    }
}
