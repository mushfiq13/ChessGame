namespace ChessLib;

public interface IChessPiece
{
    ChessPieceColor Color { get; }
    int Count { get; }
    (int File, int Rank)? Position { get; set; }
    string Unicode { get; }
}