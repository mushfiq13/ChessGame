namespace ChessLib;

public class QueenModel : ChessPiece
{
    public override int Count => 1;
    public override string Unicode { get; }

    public QueenModel(ChessPieceColor color) : base(color)
    {
        Unicode = PieceUtilities.GetUnicode(ChessPieceType.Queen, color);
    }
}
