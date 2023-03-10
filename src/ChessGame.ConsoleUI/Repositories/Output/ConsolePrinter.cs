namespace ChessGame.ConsoleUI;

internal partial class ConsoleOutput : IConsoleOutput
{
    public IConsoleOutput PrintLogo()
    {
        Console.WriteLine("    ======================================");
        Console.WriteLine("       _____ _    _ ______  _____ _____");
        Console.WriteLine("      / ____| |  | |  ____|/ ____/ ____|");
        Console.WriteLine("     | |    | |__| | |__  | (___| (___ ");
        Console.WriteLine("     | |    |  __  |  __|  \\___ \\\\___ \\ ");
        Console.WriteLine("     | |____| |  | | |____ ____) |___) |");
        Console.WriteLine("      \\_____|_|  |_|______|_____/_____/\n");
        Console.WriteLine("    ======================================\n");

        return this;
    }

    public IConsoleOutput PrintMenu()
    {
        Console.WriteLine("Commands: (N)ew game\t (M)ove \t(U)ndo \t(Q)uit ");

        return this;
    }

    public IConsoleOutput CurrentTurn(object value)
    {
        Console.WriteLine($"Current turn: {value}");

        return this;
    }

    public IConsoleOutput PrintCapturedItems(object[] items, string chessType)
    {
        if (items == null)
            return this;

        Console.Write($"\n{chessType} captured: ");

        Console.BackgroundColor = ConsoleColor.DarkYellow;

        foreach (var item in items)
        {
            Console.Write($"{item.GetType().GetProperty("Unicode")?.GetValue(item)} ");
        }

        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine("---------------------------------------------");

        return this;
    }

    public void ResetConsole() => Console.Clear();
}
