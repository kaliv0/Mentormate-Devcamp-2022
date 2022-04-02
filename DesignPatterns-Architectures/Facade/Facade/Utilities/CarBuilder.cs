namespace Facade.Utilities
{
    using Facade.Models;
    public static class CarBuilder
    {
        public static Car CreateCar()
        {
            var airflowSensor = new AirflowSensor();
            var coolingPump = new CoolingPump();
            var engine = new Engine();
            var fuelPump = new FuelPump();

            var car = new Car(airflowSensor, coolingPump, engine, fuelPump);

            return car;
        }
    }
}
