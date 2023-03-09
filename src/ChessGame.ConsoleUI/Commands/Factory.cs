namespace ChessGame.ConsoleUI;

internal static class Factory
{
    public static IConsoleInput CreateConsoleInput() => new ConsoleInput();

    public static IConsoleOutput CreateConsoleOutput() => new ConsoleOutput();

    public static IConsoleMessager CreateConsoleMessager()
       => new ConsoleMessager();
}
