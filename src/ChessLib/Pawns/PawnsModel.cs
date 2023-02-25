namespace ChessLib;

public class PawnsModel : IPiece
{

    public ChessPieceColor Color { get; private set; }
    public int Count { get; } = 8;
    public string Unicode { get; private set; }
    public (int File, int Rank) Position { get; private set; }

    public PawnsModel(ChessPieceColor color)
    {
        Color = color;
        Unicode = PieceUtilities.GetUnicode(ChessPiece.Pawns, color);
    }
}
