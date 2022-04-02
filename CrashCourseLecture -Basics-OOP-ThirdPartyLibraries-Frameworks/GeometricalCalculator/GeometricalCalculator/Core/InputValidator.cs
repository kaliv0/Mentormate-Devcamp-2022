using GeometricalCalculator.Enums;

namespace GeometricalCalculator.Core
{
    public static class InputValidator
    {
        public static bool ValidateFigure(FigureType figureType)
        {
            if (figureType == FigureType.Invalid)
            {
                Console.WriteLine("Invalid fugure type!");
                Console.WriteLine("Please try again!");

                return false;
            }

            return true;
        }

        public static bool ValidateInput()
        {
            var isValid = false;
            var input = Console.ReadLine();

            if (string.Equals(input, "Y", StringComparison.OrdinalIgnoreCase))
            {
                isValid = true;
            }
            else if (string.Equals(input, "N", StringComparison.OrdinalIgnoreCase) == false &&
                    string.Equals(input, "Y", StringComparison.OrdinalIgnoreCase) == false)
            {
                Console.WriteLine("Please press 'Y' to cotinue or 'N' to exit the program.");
                isValid = ValidateInput();
            }

            return isValid;
        }
    }
}
