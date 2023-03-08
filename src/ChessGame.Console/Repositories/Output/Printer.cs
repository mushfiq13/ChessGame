namespace ChessGame.ConsoleUI;

public partial class ConsoleOutput : IConsoleOutput
{
    public void PrintLogo()
    {
        Console.WriteLine("    ======================================");
        Console.WriteLine("       _____ _    _ ______  _____ _____");
        Console.WriteLine("      / ____| |  | |  ____|/ ____/ ____|");
        Console.WriteLine("     | |    | |__| | |__  | (___| (___ ");
        Console.WriteLine("     | |    |  __  |  __|  \\___ \\\\___ \\ ");
        Console.WriteLine("     | |____| |  | | |____ ____) |___) |");
        Console.WriteLine("      \\_____|_|  |_|______|_____/_____/\n");
        Console.WriteLine("    ======================================\n");
    }

    public void PrintMenu()
        => Console.WriteLine("Commands: (N)ew game\t (M)ove \t(U)ndo \t(Q)uit ");

    public void PrintCapturedItems(object[] whiteCaptured, object[] blackCaptured)
    {
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("WHITE captured: ");
        foreach (var item in whiteCaptured)
            Console.Write($" {item}");

        Console.WriteLine("BLACK captured: ");
        foreach (var item in blackCaptured)
            Console.Write($" {item}");

        Console.WriteLine("---------------------------------------------");
    }

    public void CurrentTurn(object value)
     => Console.WriteLine($"Current turn: {value}");
}
