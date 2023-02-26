namespace ChessLib;

public abstract class ChessPiece : IChessPiece
{
    public ChessPieceColor Color { get; }
    public abstract int Count { get; }
    public abstract string Unicode { get; }
    public (int File, int Rank) Position { get; set; } = (-1, -1);

    public ChessPiece(ChessPieceColor color) => Color = color;
}
