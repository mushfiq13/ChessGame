namespace ChessGame.Domain;

public interface IChess : IChessBase
{
    bool IsAlive { get; }
    int Rank { get; }
    int File { get; }

    bool IsMoveable(in IChess[,] tiles, int targetRank, int targetFile);
    void Move(int targetRank, int targetFile);
    void Kill();
}