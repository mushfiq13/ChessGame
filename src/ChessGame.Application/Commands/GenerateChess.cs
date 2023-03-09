using ChessGame.Domain;

namespace ChessGame.Application;

internal class GenerateChess : IGenerateChess
{
    public void CreateChessSet(ChessColor color)
    {
        CreateChess<King>(ChessType.King, color);
        CreateChess<Queen>(ChessType.Queen, color);
        CreateChess<Bishop>(ChessType.Bishop, color);
        CreateChess<Rook>(ChessType.Rook, color);
        CreateChess<Knight>(ChessType.Knight, color);
        CreateChess<Pawn>(ChessType.Pawn, color);
    }

    private void CreateChess<T>(ChessType type, ChessColor color)
        where T : IChess
    {
        (string unicode, int rank, int[] files) = ChessDataGetter.GetFixedData(type, color);

        foreach (var file in files)
        {
            T obj = Factory.CreateChess<T>(color, unicode, rank, file);

            Singleton.BoardManager.Add(obj);
        }
    }
}
