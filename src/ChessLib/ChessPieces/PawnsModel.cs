namespace ChessLib;

public class PawnsModel : ChessPiece
{
    public override int Count => 8;
    public override string Unicode { get; }

    public PawnsModel(ChessPieceColor color) : base(color)
    {
        Unicode = PieceUtilities.GetUnicode(ChessPieceType.Pawns, color);
    }
}
