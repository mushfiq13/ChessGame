namespace ChessGame.ConsoleUI;

public class ConsoleUIManager : IConsoleUIManager
{
    IFactory _factory = new Factory();

    public ILogger Logger { get; }
    public IConsoleInput ConsoleInput { get; }
    public IConsoleOutput ConsoleOutput { get; }

    public ConsoleUIManager()
    {
        Logger = _factory.CreateLogger();
        ConsoleInput = _factory.CreateConsoleInput();
        ConsoleOutput = _factory.CreateConsoleOutput();
    }
}

