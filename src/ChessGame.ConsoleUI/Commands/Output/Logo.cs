namespace ChessGame.ConsoleUI;

internal partial class ConsoleOutput
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
}
