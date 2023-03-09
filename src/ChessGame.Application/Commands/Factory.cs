using ChessGame.ConsoleUI;
using ChessGame.Domain;

namespace ChessGame.Application;

internal static class Factory
{
    public static IBoardManager CreateBoardManager()
        => new ChessBoard(new IChess[ChessConstants.RANKS, ChessConstants.FILES]);

    public static IGameServer CreateGameServer() => new GameServer();

    public static T CreateChess<T>(ChessColor color, string unicode, int rank, int file)
        where T : IChess
    {
        var type = typeof(T);
        var constructor = type.GetConstructor(new Type[] {
            typeof(ChessColor), typeof(string), typeof(int), typeof(int) });
        var instance = constructor.Invoke(new object[] { color, unicode, rank, file });

        return (T)instance;
    }

    public static IGenerateChess CreateChessCreator() => new GenerateChess();

    public static IChessHandler CreateChessHandler() => new ChessHandler();

    public static IChessDataCapture CreateChessDataCapture() => new ChessDataCapture();

    public static IConsoleManager CreateConsoleManager() => new ConsoleManager();

    public static IConsoleInput CreateConsoleInput() => new ConsoleInput();

    public static IConsoleOutput CreateConsoleOutput() => new ConsoleOutput();

    public static IConsoleMessages CreateConsoleMessages() => new ConsoleMessages();
}
