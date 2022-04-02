namespace Decorator.Models
{
    public class Employee
    {
        public Employee(string name, decimal monthlySalary)
        {
            this.Name = name;
            this.MonthlySalary = monthlySalary;
        }

        public string Name { get; set; }

        public decimal MonthlySalary { get; set; }
    }
}
