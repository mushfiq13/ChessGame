namespace ChessGame.ConsoleUI;

public interface IConsoleIOManager
{
    IConsoleInput Input { get; }
    IConsoleOutput Output { get; }
}