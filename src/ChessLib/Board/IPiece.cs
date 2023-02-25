namespace ChessLib;

public interface IPiece
{
    ChessPieceColor Color { get; }
    int Count { get; }
    string Unicode { get; }
    (int File, int Rank) Position { get; }
}