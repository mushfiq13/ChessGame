using ChessGame.Domain;

namespace ChessGame.Application;

internal class GenerateChess : IGenerateChess
{
    public List<IChess> CreateChessSet(ChessColor color)
    {
        List<IChess> chessSet = new List<IChess>();

        chessSet.AddRange(
            CreateChess<King>(ChessType.King, color));
        chessSet.AddRange(
            CreateChess<Queen>(ChessType.Queen, color));
        chessSet.AddRange(
            CreateChess<Bishop>(ChessType.Bishop, color));
        chessSet.AddRange(
            CreateChess<Rook>(ChessType.Rook, color));
        chessSet.AddRange(
            CreateChess<Knight>(ChessType.Knight, color));
        chessSet.AddRange(
            CreateChess<Pawn>(ChessType.Pawn, color));

        return chessSet;
    }

    private List<IChess> CreateChess<T>(ChessType type, ChessColor color)
        where T : IChess
    {
        List<IChess> chessObj = new List<IChess>();
        (string unicode, int rank, int[] files) = ChessDataGetter.GetFixedData(type, color);

        foreach (var file in files)
        {
            T obj = Factory.CreateChess<T>(color, unicode, rank, file);

            chessObj.Add(obj);
        }

        return chessObj;
    }
}
