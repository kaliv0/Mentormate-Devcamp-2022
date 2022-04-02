using GeometricalCalculator.Contracts;

namespace GeometricalCalculator.Models
{
    public class Sphere : IShape
    {
        public Sphere(double radius)
        {
            this.Radius = radius;
        }

        public double Radius { get; init; }

        public double CalculatePerimeter()
        {
            return 2 * Math.PI * this.Radius;
        }

        public double CalculateSurface()
        {
            return 4 * Math.PI * Math.Pow(this.Radius, 2);
        }

        public double CalculateVolume()
        {
            return (4 * Math.PI * Math.Pow(this.Radius, 3)) / 3;
        }

        public override string ToString()
        {
            return "Sphere";
        }
    }
}
