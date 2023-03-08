using ChessGame.ConsoleUI;
using ChessGame.Domain;

namespace ChessGame.Application;

internal static class Factory
{
    public static IBoardManager CreateChessBoard()
        => new BoardManager(new IChess[ChessConstants.RANKS, ChessConstants.FILES]);

    public static T CreateChess<T>(ChessColor color, string unicode, int rank, int file)
        where T : IChess
    {
        var type = typeof(T);
        var constructor = type.GetConstructor(new Type[] {
            typeof(ChessColor), typeof(string), typeof(int), typeof(int) });
        var instance = constructor.Invoke(new object[] { color, unicode, rank, file });

        return (T)instance;
    }

    public static IGameCommands CreatePieceCommands() => new GameCommands();

    public static StandardMessages CreateStandardMessages() => new StandardMessages();

    public static IConsoleInput CreateConsoleInput() => new ConsoleInput();

    public static IConsoleOutput CreateConsoleOutput() => new ConsoleOutput();

    public static IConsoleUICommands CreateConsoleUICommands() => new ConsoleUICommands();
}
