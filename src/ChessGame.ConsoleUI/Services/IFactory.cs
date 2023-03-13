namespace ChessGame.ConsoleUI
{
    internal interface IFactory
    {
        IConsoleInput CreateConsoleInput();
        IConsoleOutput CreateConsoleOutput();
        ILogger CreateLogger();
    }
}