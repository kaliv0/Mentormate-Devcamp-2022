using Factory.Models;

var factory = new TransportFactory();

Console.WriteLine("Using transport on ground.");
var landOrder = "land";
var truck = factory.CreateTransport(landOrder);
truck.StartEngine();
Console.WriteLine("-------------");

Console.WriteLine("Using air transport.");
var airOrder = "air";
var airplane = factory.CreateTransport(airOrder);
airplane.StartEngine();
Console.WriteLine("-------------");

Console.WriteLine("Using sea transport.");
var seaOrder = "sea";
var ferry = factory.CreateTransport(seaOrder);
ferry.StartEngine();
