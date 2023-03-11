namespace ChessGame.ConsoleUI;

internal static class Factory
{
    public static IConsoleInput CreateConsoleInput() => new ConsoleInput();

    public static IConsoleOutput CreateConsoleOutput() => new ConsoleOutput();
}
