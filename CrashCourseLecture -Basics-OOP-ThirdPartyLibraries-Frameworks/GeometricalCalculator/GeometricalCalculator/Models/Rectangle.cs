namespace GeometricalCalculator.Models
{
    public class Rectangle : Paralelogram
    {
        public Rectangle(double lenght, double width)
            : base(lenght, width, width)
        {
        }

        public override string ToString()
        {
            return "Rectangle";
        }
    }
}
