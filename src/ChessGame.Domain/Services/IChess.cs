namespace ChessGame.Domain;

public interface IChess : IChessBase
{
    bool IsAlive { get; }
    int Rank { get; }
    int File { get; }

    bool Move(in IChess[,] tiles, int targetRank, int targetFile);
    void Kill();
}