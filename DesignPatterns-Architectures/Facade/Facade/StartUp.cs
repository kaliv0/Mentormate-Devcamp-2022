using Facade.Utilities;

var car = CarBuilder.CreateCar();
var driver = new FacadeDriver(car);

driver.Start();
Console.WriteLine("------------");
driver.Stop();



