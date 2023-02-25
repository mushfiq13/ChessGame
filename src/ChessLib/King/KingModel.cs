namespace ChessLib;

public class KingModel : IPiece
{
    public ChessPieceColor Color { get; private set; }
    public int Count { get; } = 1;
    public string Unicode { get; private set; }
    public (int File, int Rank) Position { get; private set; }

    public KingModel(ChessPieceColor color)
    {
        Color = color;
        Unicode = PieceUtilities.GetUnicode(ChessPiece.King, color);
    }
}
