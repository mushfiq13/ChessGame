namespace ChessGame.ConsoleUI;

public interface IConsoleManager
{
    IConsoleInput Input { get; }
    IConsoleMessager Messager { get; }
    IConsoleOutput Output { get; }
}