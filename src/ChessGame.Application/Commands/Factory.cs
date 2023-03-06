using ChessGame.Domain;
using ChessGame.Presentation;

namespace ChessGame.Application;

internal static class Factory
{
    public static IChessBoard CreateChessBoard() => new ChessBoard();

    public static PieceCommands CreatePieceCommands(IChessBoard board) => new PieceCommands(board);

    public static IInputQueries CreateInputQueries() => new InputQueries();

    public static IInputCommands CreateInputCommands() => new InputCommands(new ConsoleInput());

    public static IOutputCommands CreateOutputCommands() => new OutputCommands(new ConsoleOutput());

    public static IChess CreateKing(ChessColor color, string unicode, int rank, int file)
        => new King(color, unicode, rank, file);

    public static IChess CreateQueen(ChessColor color, string unicode, int rank, int file)
        => new Queen(color, unicode, rank, file);

    public static IChess CreateBishop(ChessColor color, string unicode, int rank, int file)
        => new Bishop(color, unicode, rank, file);

    public static IChess CreateRook(ChessColor color, string unicode, int rank, int file)
        => new Rook(color, unicode, rank, file);

    public static IChess CreateKnight(ChessColor color, string unicode, int rank, int file)
        => new Knight(color, unicode, rank, file);

    public static IChess CreatePawn(ChessColor color, string unicode, int rank, int file)
        => new Pawn(color, unicode, rank, file);
}
