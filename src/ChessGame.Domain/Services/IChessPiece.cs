namespace ChessGame.Domain;

public interface IChessPiece
{
    ChessPieceColor Color { get; }
    bool IsAlive { get; }
    (int Rank, int File) Position { get; }
    string Unicode { get; }

    void Kill();
    void Move(int destRank, int destFile);

    bool CanMove(in IChessPiece[,] board, int targetRank, int targetFile);
}