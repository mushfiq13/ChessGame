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

    public IConsoleOutput PrintWhiteCapturedItems(object[] whiteCaptured)
    {
        PrintCapturedItems(whiteCaptured, "WHTIE");

        return this;
    }

    public IConsoleOutput PrintBlackCapturedItems(object[] blackCaptured)
    {
        PrintCapturedItems(blackCaptured, "BLACK");

        return this;
    }

    public IConsoleOutput CurrentTurn(object value)
    {
        Console.WriteLine($"Current turn: {value}");

        return this;
    }

    private void PrintCapturedItems(object[] items, string itemType)
    {
        if (items == null)
            return;

        Console.Write($"\n{itemType} captured: ");

        Console.BackgroundColor = ConsoleColor.DarkYellow;

        foreach (var item in items)
        {
            Console.Write($"{item.GetType().GetProperty("Unicode")?.GetValue(item)} ");
        }

        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine("---------------------------------------------");
    }

    public void ResetConsole() => Console.Clear();
}
