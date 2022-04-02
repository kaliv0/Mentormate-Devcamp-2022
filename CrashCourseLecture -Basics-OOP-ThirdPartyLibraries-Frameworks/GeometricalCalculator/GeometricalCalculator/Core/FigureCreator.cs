using GeometricalCalculator.Contracts;
using GeometricalCalculator.Enums;
using GeometricalCalculator.Models;

namespace GeometricalCalculator.Core
{
    public static class FigureCreator
    {
        public static IShape ActivateConstruction(FigureType figureType)
        {
            if (figureType == FigureType.Invalid)
            {
                Console.WriteLine("Invalid fugure type!");
                Console.WriteLine("Please try again!");
            }

            IShape figure = CreateFigure(figureType);
            return figure;
        }

        private static IShape CreateFigure(FigureType figureType)
        {
            switch (figureType)
            {
                case FigureType.Circle:
                    {
                        double radius = CalculatorIO.AskUserForDetails("radius");
                        return new Circle(radius);
                    }

                case FigureType.Paralelogram:
                    {
                        double @base = CalculatorIO.AskUserForDetails("base");
                        double height = CalculatorIO.AskUserForDetails("height");
                        double adjacentSide = CalculatorIO.AskUserForDetails("adjacentSide");
                        return new Paralelogram(@base, height, adjacentSide);
                    }

                case FigureType.Rectangle:
                    {
                        double length = CalculatorIO.AskUserForDetails("length");
                        double width = CalculatorIO.AskUserForDetails("width");
                        return new Rectangle(length, width);
                    }

                case FigureType.Sphere:
                    {
                        double radius = CalculatorIO.AskUserForDetails("radius");
                        return new Sphere(radius);
                    }

                case FigureType.Square:
                    {
                        double side = CalculatorIO.AskUserForDetails("side");
                        return new Square(side);
                    }

                case FigureType.Triangle:
                    {
                        double sideA = CalculatorIO.AskUserForDetails("side A");
                        double sideB = CalculatorIO.AskUserForDetails("side B");
                        double sideC = CalculatorIO.AskUserForDetails("side C");
                        return new Triangle(sideA, sideB, sideC);
                    }
            }

            return null; //bad idea!

        }

        public static string CalculateAttributes(IShape figure)
        {
            var attributes = new List<double>();
            var perimeter = figure.CalculatePerimeter();
            var surface = figure.CalculateSurface();

            attributes.Add(perimeter);
            attributes.Add(surface);

            if (figure.GetType() == typeof(Sphere))
            {
                var sphere = (Sphere)figure;
                var volume = sphere.CalculateVolume();
                attributes.Add(volume);
            }

            else if (figure.GetType() == typeof(Triangle))
            {
                var triangle = (Triangle)figure;
                var radiusOfCircumcircle = triangle.caculateRadiusOfCircumcircle();
                attributes.Add(radiusOfCircumcircle);
            }

            var attributesInfo = CalculatorIO.ConstructMessage(figure, attributes);
            return attributesInfo;
        }
    }
}
