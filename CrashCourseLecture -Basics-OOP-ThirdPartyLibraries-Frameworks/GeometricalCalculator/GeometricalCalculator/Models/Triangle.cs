using GeometricalCalculator.Contracts;

namespace GeometricalCalculator.Models
{
    public class Triangle : IShape
    {
        public Triangle(double sideA, double sideB, double sideC)
        {
            this.SideA = sideA;
            this.SideB = sideB;
            this.SideC = sideC;
        }

        public double SideA { get; init; }

        public double SideB { get; init; }

        public double SideC { get; init; }

        public double CalculatePerimeter()
        {
            return this.SideA + this.SideB + this.SideC;
        }

        public double CalculateSurface()
        {
            // Heron's formula:
            // Area = SquareRoot(s * (s - a) * (s - b) * (s - c)) 
            // where s = (a + b + c) / 2, or 1/2 of the perimeter of the triangle 

            double temp = this.CalculatePerimeter() / 2;
            return Math.Sqrt(temp * (temp - SideA) * (temp - SideB) * (temp - SideC));
        }

        public double caculateRadiusOfCircumcircle()
        {
            var numerator = (SideA * SideB * SideC);
            var denominator = (SideA + SideB + SideC) * (SideB + SideC - SideA)
                            * (SideC + SideA - SideB) * (SideA + SideB - SideC);

            return (numerator / Math.Sqrt(denominator));
        }

        public override string ToString()
        {
            return "Triangle";
        }
    }
}
