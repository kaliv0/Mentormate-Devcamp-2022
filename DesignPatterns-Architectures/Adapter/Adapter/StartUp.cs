using Adapter.Contracts;
using Adapter.Models;

IAmericanSpeedometer americanSpeedometer = new AmericanSpeedometer();
Console.WriteLine("Testing American speedometer");
americanSpeedometer.LogSpeed(62.14);

var europeanSpeedometer = new EuropeanSpeedometer();
americanSpeedometer = new SpeedometerAdapter(europeanSpeedometer);
Console.WriteLine("Testing American speedometer with adapter");
americanSpeedometer.LogSpeed(62.14);