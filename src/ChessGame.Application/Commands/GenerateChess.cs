using ChessGame.Domain;

namespace ChessGame.Application;

internal class GenerateChess
{
    public static void CreateChessSet(IBoardManager board, ChessColor color)
    {
        CreateChess<King>(board, ChessType.King, color);
        CreateChess<Queen>(board, ChessType.Queen, color);
        CreateChess<Bishop>(board, ChessType.Bishop, color);
        CreateChess<Rook>(board, ChessType.Rook, color);
        CreateChess<Knight>(board, ChessType.Knight, color);
        CreateChess<Pawn>(board, ChessType.Pawn, color);
    }

    private static void CreateChess<T>(IBoardManager board, ChessType type, ChessColor color)
        where T : IChess
    {
        (string unicode, int rank, int[] files) = ChessDataGetter.GetFixedData(type, color);

        foreach (var file in files)
        {
            T obj = Factory.CreateChess<T>(color, unicode, rank, file);

            board.Add(obj);
        }
    }
}
