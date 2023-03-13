namespace ChessGame.ConsoleUI;

public class ConsoleUIManager : IConsoleUIManager
{
    public ILogger Logger { get; } = new Logger();
    public IConsoleInput ConsoleInput { get; } = new ConsoleInput();
    public IConsoleOutput ConsoleOutput { get; } = new ConsoleOutput();
}

