namespace ChessGame.Domain;

public interface IChessPiece
{
    ChessPieceColor Color { get; }
    (int Rank, int File) Position { get; set; }
    string Unicode { get; }
    bool IsAlive { get; set; }

    bool IsDestinationTileValid(int destRank, int destFile);
}