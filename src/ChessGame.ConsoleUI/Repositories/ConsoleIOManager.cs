namespace ChessGame.ConsoleUI;

public class ConsoleIOManager : IConsoleIOManager
{
    public IConsoleInput Input { get; } = Factory.CreateConsoleInput();
    public IConsoleOutput Output { get; } = Factory.CreateConsoleOutput();
}
