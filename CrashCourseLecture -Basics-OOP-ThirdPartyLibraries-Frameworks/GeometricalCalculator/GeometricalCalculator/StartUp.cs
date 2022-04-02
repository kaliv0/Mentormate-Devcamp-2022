using GeometricalCalculator.Core;

namespace GeometricalCalculator
{
    public class StartUp
    {
        public static void Main()
        {
            while (true)
            {
                CalculatorIO.PromptUser();
                var figureType = CalculatorIO.ReadUserInput();
                var isValidInput = InputValidator.ValidateFigure(figureType);

                if (!isValidInput)
                {
                    continue;
                }

                var figure = FigureCreator.ActivateConstruction(figureType);
                var attributes = FigureCreator.CalculateAttributes(figure);

                CalculatorIO.DisplayResult(figure, attributes);

                var shouldContinue = InputValidator.ValidateInput();

                if (!shouldContinue)
                {
                    CalculatorIO.SerializeResult();
                    CalculatorIO.DisplayEndMessage();
                    break;
                }
            }
        }
    }
}
