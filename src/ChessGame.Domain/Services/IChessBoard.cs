namespace ChessGame.Domain;

public interface IChessBoard
{
    IChess[,] Tiles { get; }

    void Add(in IChess item);
    bool Contains(in IChess item);
    void Set(in IChess item, int targetRank, int targetFile);
    void Remove(int rank, int file);
}