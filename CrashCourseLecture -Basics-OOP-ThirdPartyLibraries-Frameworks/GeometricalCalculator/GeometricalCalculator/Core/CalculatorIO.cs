using System.Text;
using GeometricalCalculator.Contracts;
using GeometricalCalculator.Enums;
using GeometricalCalculator.Models;
using Newtonsoft.Json;

namespace GeometricalCalculator.Core
{
    public static class CalculatorIO
    {
        private const string SerializedResultsPath = "../../../Results";

        private static List<object> DTOs = new List<object>();


        public static void PromptUser()
        {
            Console.WriteLine("Choose a figure to calculate its parameters:");
            Console.WriteLine("Choose between: circle, sphere, triangle, paralelogram, rectangle and square.");
        }

        public static FigureType ReadUserInput()
        {
            string userInput = Console.ReadLine();

            if (!Enum.TryParse(userInput, true, out FigureType figureType))
            {
                return FigureType.Invalid;
            }

            return figureType;
        }


        public static double AskUserForDetails(string neededValue)
        {
            Console.WriteLine($"Enter value for {neededValue}");

            var isValidDetail = double.TryParse(Console.ReadLine(), out double value);

            if (!isValidDetail)
            {
                Console.WriteLine("Please enter valid information!");
                value = AskUserForDetails(neededValue);
            }

            return value;

        }

        public static string ConstructMessage(IShape figure, List<double> attributes)
        {
            var sb = new StringBuilder();

            sb.Append($"Your {figure} has ");

            if (figure.GetType() == typeof(Circle))
            {
                sb.Append($"Circumference {attributes[0]:F2} ");
                sb.Append($"and Area {attributes[1]:F2}.");
            }
            else if (figure.GetType() == typeof(Sphere))
            {
                sb.Append($"Circumference {attributes[0]:F2}, ");
                sb.Append($"Surface {attributes[1]:F2} ");
                sb.Append($"and Volume {attributes[1]:F2}.");
            }
            else if (figure.GetType() == typeof(Triangle))
            {
                sb.Append($"Perimeter {attributes[0]:F2}, ");
                sb.Append($"Area {attributes[1]:F2} ");
                sb.Append($"and Radius of Circumcircle is {attributes[2]:F2}.");
            }
            else
            {
                sb.Append($"Perimeter {attributes[0]:F2} ");
                sb.Append($"and Area {attributes[1]:F2}.");
            }

            return sb.ToString();
        }

        public static void DisplayResult(IShape figure, string attributes)
        {
            Console.WriteLine(attributes);
            PrepareForSerialization(figure, attributes);

            Console.WriteLine("Press 'Y' to cotinue or 'N' to exit the program.");
        }

        public static void DisplayEndMessage()
        {
            Console.WriteLine("Good Bye!");
        }

        public static void SerializeResult()
        {
            var JSON_Result = JsonConvert.SerializeObject(DTOs, Formatting.Indented);
            File.AppendAllText($"{SerializedResultsPath}/figure-attributes.json", JSON_Result);
        }

        private static void PrepareForSerialization(IShape figure, string creationalMessage)
        {
            var newDTO = new
            {
                typeOfFigure = figure.ToString(),
                creationalMessage = creationalMessage
            };

            DTOs.Add(newDTO);
        }
    }
}
