using GeometricalCalculator.Contracts;

namespace GeometricalCalculator.Models
{
    public class Paralelogram : IShape
    {
        public Paralelogram(double @base, double height, double adjacentSide)
        {
            this.Base = @base;
            this.Height = height;
            this.AdjacentSide = adjacentSide;
        }

        public double Base { get; init; }

        public double Height { get; init; }

        public double AdjacentSide { get; init; }

        public double CalculatePerimeter()
        {
            return 2 * (this.Base + this.AdjacentSide);
        }

        public double CalculateSurface()
        {
            return this.Base * this.Height;
        }

        public override string ToString()
        {
            return "Paralelogram";
        }
    }
}
