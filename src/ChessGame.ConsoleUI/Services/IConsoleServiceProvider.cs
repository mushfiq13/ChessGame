namespace ChessGame.ConsoleUI;

public interface IConsoleServiceProvider
{
    ILogger GetLogger();
    IConsoleInput GetConsoleInput();
    IConsoleOutput GetConsoleOutput();
}