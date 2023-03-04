using ChessGame.Domain;
using ChessGame.Presentation;

namespace ChessGame.Application;

internal static class Factory
{
    public static IChessPiece[,] CreateChessBoard() => new IChessPiece[ChessConstants.RANKS, ChessConstants.FILES];

    public static IChessPlayer CreateWhiteChessPlayer() => new WhiteChessPlayer();

    public static IChessPlayer CreateBlackChessPlayer() => new BlackChessPlayer();

    public static IChessRepositoryManager CreateChessRepository() => new ChessRepository();

    public static IPieceCommands CreatePieceCommands(IChessRepositoryManager manager) => new PieceCommands(manager);

    public static IInputQueries CreateInputQueries() => new InputQueries();

    public static IPieceQueries CreatePieceQueries(IChessPiece[,] tiles) => new PieceQueries(tiles);

    public static IInputCommands CreateInputCommands() => new InputCommands(new ConsoleInput());

    public static IOutputCommands CreateOutputCommands() => new OutputCommands(new ConsoleOutput());
}
