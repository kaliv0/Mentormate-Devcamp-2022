namespace Decorator.Contracts
{
    using Decorator.Models;

    public interface ICalculator
    {
        decimal CalculateSalary(Employee employee);
    }
}
