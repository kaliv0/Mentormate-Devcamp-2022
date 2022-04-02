using GeometricalCalculator.Contracts;

namespace GeometricalCalculator.Models
{
    public class Circle : IShape
    {
        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius { get; init; }

        public double CalculateSurface()
        {
            return Math.PI * Math.Pow(this.Radius, 2);
        }

        public double CalculatePerimeter()
        {
            return 2 * Math.PI * this.Radius;
        }

        public override string ToString()
        {
            return "Circle";
        }
    }
}
