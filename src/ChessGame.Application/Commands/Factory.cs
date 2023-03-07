using ChessGame.ConsoleUI;
using ChessGame.Domain;

namespace ChessGame.Application;

internal static class Factory
{
    public static IChessManager CreateChessBoard()
        => new Domain.ChessManager(new IChess[ChessConstants.RANKS, ChessConstants.FILES]);

    public static T CreateChess<T>(ChessColor color, string unicode, int rank, int file)
        where T : IChess
    {
        var type = typeof(T);
        var constructor = type.GetConstructor(new Type[] {
            typeof(ChessColor), typeof(string), typeof(int), typeof(int) });
        var instance = constructor.Invoke(new object[] { color, unicode, rank, file });

        return (T)instance;
    }

    public static IPieceCommands CreatePieceCommands(IChessManager board) => new PieceCommands(board);

    public static IInputQueries CreateInputQueries() => new InputQueries();

    public static IInputCommands CreateInputCommands() => new InputCommands(new ConsoleInput());

    public static IOutputCommands CreateOutputCommands() => new OutputCommands(new ConsoleOutput());

    public static IChessQueries CreateChessQueries() => new ChessQueries();
}
