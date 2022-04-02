using Decorator.Contracts;
using Decorator.Models;

var employee = new Employee("Foobar", 500M);
ICalculator calculator = new SalaryCalculator();
var yearlySalary = calculator.CalculateSalary(employee);

Console.WriteLine($"Calculating yearly salary of {employee.Name} using calculator:");
Console.WriteLine($"${yearlySalary:F2}");

var calculatorDecorator = new CalculatorDecorator(calculator);
yearlySalary = calculatorDecorator.CalculateSalary(employee);
var yearlySalaryWithBonus = calculatorDecorator.CalculateSalary(employee, 0.05M);

Console.WriteLine($"Calculating yearly salary of {employee.Name} using calculator decorator:");
Console.WriteLine($"Yearly salary - ${yearlySalary:F2}");
Console.WriteLine($"Yearly salary with bonus - ${yearlySalaryWithBonus:F2}");