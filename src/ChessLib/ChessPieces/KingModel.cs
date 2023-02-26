namespace ChessLib;

public class KingModel : ChessPiece
{
    public override int Count => 1;
    public override string Unicode { get; }

    public KingModel(ChessPieceColor color) : base(color)
    {
        Unicode = PieceUtilities.GetUnicode(ChessPieceType.King, color);
    }
}
