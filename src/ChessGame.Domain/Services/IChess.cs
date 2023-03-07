namespace ChessGame.Domain;

public interface IChess : IChessCore
{
    bool IsDead { get; }

    bool IsMoveable(in IChessCore[,] tiles, int targetRank, int targetFile);
    void Move(int targetRank, int targetFile);
    void Kill();
}