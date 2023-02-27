namespace ChessLib;

public abstract class ChessPiece : IChessPiece
{
    public ChessPieceColor Color { get; }
    public abstract int Count { get; }
    public abstract string Unicode { get; }
    public (int File, int Rank)? Position { get; set; } = default;

    public ChessPiece(ChessPieceColor color) => Color = color;
}
