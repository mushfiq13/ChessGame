namespace ChessGame.Domain;

public interface IChessBoard : IChessRepository
{
    int Count { get; }

    void Add(IChess item);
    bool Contains(IChess item);
    void Remove(IChess item);
    void Move(IChess item, int targetRank, int targetFile);
    void Remove(int rank, int file);
}