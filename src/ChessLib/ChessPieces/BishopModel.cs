namespace ChessLib;

public class BishopModel : ChessPiece
{
    public override int Count => 2;
    public override string Unicode { get; }

    public BishopModel(ChessPieceColor color) : base(color)
    {
        Unicode = PieceUtilities.GetUnicode(ChessPieceType.Bishop, color);
    }
}
