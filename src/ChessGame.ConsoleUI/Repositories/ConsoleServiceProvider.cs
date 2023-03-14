namespace ChessGame.ConsoleUI;

public class ConsoleServiceProvider : IConsoleServiceProvider
{
    private static readonly IConsoleServiceProvider _instance = new ConsoleServiceProvider();

    private ConsoleServiceProvider() { }

    public static IConsoleServiceProvider GetServices() => _instance;

    public ILogger GetLogger() => Logger.GetInstance();

    public IConsoleInput GetConsoleInput() => ConsoleInput.GetInstance();

    public IConsoleOutput GetConsoleOutput() => ConsoleOutput.GetInstance();
}