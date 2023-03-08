using ChessGame.Domain;

namespace ChessGame.Application;

internal class ChessGenerator
{
    public static void AddEntireChessSet(IBoardManager board, ChessColor color)
    {
        AddChess<King>(board, ChessType.King, color);
        AddChess<Queen>(board, ChessType.Queen, color);
        AddChess<Bishop>(board, ChessType.Bishop, color);
        AddChess<Rook>(board, ChessType.Rook, color);
        AddChess<Knight>(board, ChessType.Knight, color);
        AddChess<Pawn>(board, ChessType.Pawn, color);
    }

    private static void AddChess<T>(IBoardManager board, ChessType type, ChessColor color)
        where T : IChess
    {
        (string unicode, int rank, int[] files) = ChessQuery.GetFixedData(type, color);

        foreach (var file in files)
        {
            T obj = Factory.CreateChess<T>(color, unicode, rank, file);

            board.Add(obj);
        }
    }
}
