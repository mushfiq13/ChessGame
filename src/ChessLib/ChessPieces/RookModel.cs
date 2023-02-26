namespace ChessLib;
public class RookModel : ChessPiece
{
    public override int Count => 2;
    public override string Unicode { get; }

    public RookModel(ChessPieceColor color) : base(color)
    {
        Unicode = PieceUtilities.GetUnicode(ChessPieceType.Rook, color);
    }
}
