namespace ChessGame.Domain;

public interface IChessPiece
{
    ChessPieceColor Color { get; }
    bool IsAlive { get; set; }
    (int Rank, int File) Position { get; set; }
    string Unicode { get; }
}