namespace Decorator.Models
{
    using Decorator.Contracts;

    public class SalaryCalculator : ICalculator
    {
        public decimal CalculateSalary(Employee employee)
        {
            return employee.MonthlySalary * 12;
        }
    }
}
