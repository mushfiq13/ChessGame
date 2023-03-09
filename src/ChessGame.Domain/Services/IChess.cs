namespace ChessGame.Domain;

public interface IChess : IChessCore
{
    bool IsKilled { get; }

    void Kill();
    void Set(int newRank, int newFile);
    bool IsMoveable(in IChessCore[,] tiles, int targetRank, int targetFile);
}