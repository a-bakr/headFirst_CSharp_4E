using AbilityScoreTester;

var calculator = new AbilityScoreCalculator();

while (true)
{
    calculator.RollResult = Inputs.ReadInt(calculator.RollResult, "Starting 4d6 roll");
    calculator.DivideBy = Inputs.ReadDouble(calculator.DivideBy, "Divide by");
    calculator.AddAmount = Inputs.ReadInt(calculator.AddAmount, "Add amount");
    calculator.Minimum = Inputs.ReadInt(calculator.Minimum, "Minimum");

    calculator.CalculateAbilityScore();
    Console.WriteLine("Calculated ability score: " + calculator.Score);
    Console.WriteLine("Press Q to quit, any other key to continue");
    char keyChar = Console.ReadKey(true).KeyChar;
    if (keyChar == 'Q' || keyChar == 'q') return;
}

public static class Inputs
{
    /// <summary>
    /// Writes a prompt and reads an int value from the console.
    /// </summary>
    /// <param name="lastUsedValue">The default value.</param>
    /// <param name="prompt">Prompt to print to the console.</param>
    /// <returns>The int value read, or the default value if unable to parse</returns>
    public static int ReadInt(int lastUsedValue, string prompt)
    {
        Console.Write($"{prompt} [{lastUsedValue}] ");
        var input = Console.ReadLine()?.Trim();
        if (int.TryParse(input, out int inputNum))
        {
            Console.WriteLine($"   using value {inputNum}");
            return inputNum;
        }
        else
        {
            Console.WriteLine($"   using default value {lastUsedValue}");
            return lastUsedValue;
        }
    }

    /// <summary>
    /// Writes a prompt and reads a double value from the console.
    /// </summary>
    /// <param name="lastUsedValue">The default value.</param>
    /// <param name="prompt">Prompt to print to the console.</param>
    /// <returns>The double value read, or the default value if unable to parse</returns>
    public static double ReadDouble(double lastUsedValue, string prompt)
    {
        Console.Write($"{prompt} [{lastUsedValue}] ");
        var input = Console.ReadLine()?.Trim();
        if (double.TryParse(input, out double inputNum))
        {
            Console.WriteLine($"   using value {inputNum}");
            return inputNum;
        }
        else
        {
            Console.WriteLine($"   using default value {lastUsedValue}");
            return lastUsedValue;
        }
    }
}