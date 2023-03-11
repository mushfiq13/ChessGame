using ChessGame.Domain;

namespace ChessGame.Application;

internal class ChessSetCreator : IChessSetCreator
{
    public List<IChess> Create(ChessColor color)
    {
        List<IChess> chessSet = new List<IChess>();

        chessSet.AddRange(Create<King>(ChessType.King, color));
        chessSet.AddRange(Create<Queen>(ChessType.Queen, color));
        chessSet.AddRange(Create<Bishop>(ChessType.Bishop, color));
        chessSet.AddRange(Create<Rook>(ChessType.Rook, color));
        chessSet.AddRange(Create<Knight>(ChessType.Knight, color));
        chessSet.AddRange(Create<Pawn>(ChessType.Pawn, color));

        return chessSet;
    }

    private List<IChess> Create<T>(ChessType type, ChessColor color)
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
