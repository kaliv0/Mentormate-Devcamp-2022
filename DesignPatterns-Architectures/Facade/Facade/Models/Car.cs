namespace Facade.Models
{
    public class Car
    {
        public Car(
            AirflowSensor airflowSensor, CoolingPump coolingPump,
            Engine engine, FuelPump fuelPump)
        {
            AirflowSensor = airflowSensor;
            FuelPump = fuelPump;
            Engine = engine;
            CoolingPump = coolingPump;
        }

        public AirflowSensor AirflowSensor { get; set; }

        public FuelPump FuelPump { get; set; }

        public Engine Engine { get; set; }

        public CoolingPump CoolingPump { get; set; }
    }
}
