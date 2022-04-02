namespace GeometricalCalculator.Models
{
    public class Square : Rectangle
    {
        public Square(double side)
            : base(side, side)
        {
        }

        public override string ToString()
        {
            return "Square";
        }
    }
}
