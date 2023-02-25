namespace ChessLib;

public class RookModel : IPiece
{
    public ChessPieceColor Color { get; private set; }
    public int Count { get; } = 2;
    public string Unicode { get; private set; }
    public (int File, int Rank) Position { get; private set; }

    public RookModel(ChessPieceColor color)
    {
        Color = color;
        Unicode = PieceUtilities.GetUnicode(ChessPiece.Rook, color);
    }
}

