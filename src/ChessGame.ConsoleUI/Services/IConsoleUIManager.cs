namespace ChessGame.ConsoleUI;

public interface IConsoleUIManager
{
    IConsoleInput ConsoleInput { get; }
    IConsoleOutput ConsoleOutput { get; }
    ILogger Logger { get; }
}