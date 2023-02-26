namespace ChessLib;

public class KnightModel : ChessPiece
{
    public override int Count => 2;
    public override string Unicode { get; }

    public KnightModel(ChessPieceColor color) : base(color)
    {
        Unicode = PieceUtilities.GetUnicode(ChessPieceType.Knight, color);
    }
}
