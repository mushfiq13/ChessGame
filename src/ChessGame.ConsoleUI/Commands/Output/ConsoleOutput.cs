namespace ChessGame.ConsoleUI;

internal partial class ConsoleOutput : IConsoleOutput
{
    private static readonly IConsoleOutput _instance = new ConsoleOutput();

    private ConsoleOutput() { }

    public static IConsoleOutput GetInstance() => _instance;

    public void Write(string text)
    {
        Console.WriteLine(text);
    }
}
