namespace ChessGame.ConsoleUI;

internal partial class ConsoleOutput
{
    private void Colorize(object obj, ConsoleColor consoleBackgroundColor = ConsoleColor.Green)
    {
        Console.BackgroundColor = consoleBackgroundColor;
        Console.ForegroundColor = obj?.GetType()
            .GetProperty("Color")
            .GetValue(obj)
            .ToString()
            .Contains("White", StringComparison.OrdinalIgnoreCase) is true
                ? ConsoleColor.White : ConsoleColor.Black;
    }
}
