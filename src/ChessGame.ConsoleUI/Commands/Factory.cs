namespace ChessGame.ConsoleUI;

internal class Factory : IFactory
{
    public IConsoleInput CreateConsoleInput() => new ConsoleInput();

    public IConsoleOutput CreateConsoleOutput() => new ConsoleOutput();

    public ILogger CreateLogger() => new Logger();
}
