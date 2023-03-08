namespace ChessGame.Domain;

public interface IChess : IChessCore
{
    bool IsKilled { get; }

    void Kill();
    void Set(int rank, int file);
    bool IsMoveable(in IChessCore[,] tiles, int targetRank, int targetFile);
}