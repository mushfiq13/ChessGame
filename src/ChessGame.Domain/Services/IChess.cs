namespace ChessGame.Domain;

public interface IChess : IChessBase
{
    bool IsDead { get; }

    bool IsMoveable(in IChessBase[,] tiles, int targetRank, int targetFile);
    void Move(int targetRank, int targetFile);
    void Kill();
}