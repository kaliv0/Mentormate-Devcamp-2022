namespace Decorator.Models
{
    using Decorator.Contracts;

    public class CalculatorDecorator : ICalculator
    {
        private ICalculator _salaryCalculator;

        public CalculatorDecorator(ICalculator salaryCalculator)
        {
            _salaryCalculator = salaryCalculator;
        }       

        public decimal CalculateSalary(Employee employee)
        {
            return _salaryCalculator.CalculateSalary(employee);
        }

        public decimal CalculateSalary(Employee employee, decimal bonus)
        {
            return _salaryCalculator.CalculateSalary(employee) + this.CalculateBonus(employee, bonus);
        }

        private decimal CalculateBonus(Employee employee, decimal bonus)
        {
            return _salaryCalculator.CalculateSalary(employee) * bonus;
        }
    }
}
