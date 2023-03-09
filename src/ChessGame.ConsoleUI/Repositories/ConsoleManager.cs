namespace ChessGame.ConsoleUI;

public class ConsoleManager : IConsoleManager
{
    public IConsoleInput Input { get; } = Factory.CreateConsoleInput();
    public IConsoleOutput Output { get; } = Factory.CreateConsoleOutput();
    public IConsoleMessager Messager { get; } = Factory.CreateConsoleMessager();
}
