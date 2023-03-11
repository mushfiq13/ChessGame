using ChessGame.ConsoleUI;
using ChessGame.Domain;

namespace ChessGame.Application;

internal static class Factory
{
    public static IChessBoard CreateChessBoard()
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
    public static IChessSetCreator CreateChessSetCreator() => new ChessSetCreator();

    public static IChessHandler CreateChessHandler() => new ChessHandler();

    // Capture
    public static ICaptureProcessor CreateCaptureProcessor() => new CaptureProcessor();

    public static ICapturer CreateCapturer() => new Capturer();

    public static ICaptureValidator CreateCaptureValidator() => new CaptureValidator();

    public static ISourceTileCaptureHandler CreateSourceTileCaptureHandler(int maxCapturingLimit = 1)
        => new SourceTileCaptureHandler(maxCapturingLimit);

    public static ITargetTileCaptureHandler CreateTargetTileCaptureHandler(int maxCapturingLimit = 1)
        => new TargetTileCaptureHandler(maxCapturingLimit);

    // Console
    public static IConsoleIOManager CreateConsoleIOManager() => new ConsoleIOManager();

    public static ILogger CreateLogger() => new Logger();

}
