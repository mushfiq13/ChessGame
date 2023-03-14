namespace ChessGame.ConsoleUI;

internal class ConsoleInput : IConsoleInput
{
    private static readonly IConsoleInput _instance = new ConsoleInput();

    private ConsoleInput() { }

    public static IConsoleInput GetInstance() => _instance;

    public string Reader() => Console.ReadLine();
}
