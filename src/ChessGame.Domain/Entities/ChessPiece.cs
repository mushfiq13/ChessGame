namespace ChessGame.Domain;

public abstract class ChessPiece : IChessPiece
{
    bool _isAlive = true;

    public (int Rank, int File) Position { get; private set; }

    public bool IsAlive => _isAlive;
    public abstract ChessPieceColor Color { get; }
    public abstract string Unicode { get; }

    public ChessPiece(int rank, int file) => Position = (rank, file);

    public void Kill()
    {
        Position = (-1, -1);
        _isAlive = false;
    }

    public void Move(int destRank, int destFile) => Position = (destRank, destFile);

    public abstract bool CanMove(in IChessPiece[,] board, int targetRank, int targetFile);
}
