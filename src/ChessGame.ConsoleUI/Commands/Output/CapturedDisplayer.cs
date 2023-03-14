namespace ChessGame.ConsoleUI;

internal partial class ConsoleOutput
{
    public IConsoleOutput PrintCapturedItems(object[] items, string chessType)
    {
        if (items == null)
            return this;

        Console.Write($"{chessType} captured: ");

        foreach (var item in items)
        {
            Colorize(item);

            Console.Write($"{item.GetType().GetProperty("Unicode")?.GetValue(item)}  ");
            Console.ResetColor();
        }

        Console.WriteLine();

        return this;
    }
}
