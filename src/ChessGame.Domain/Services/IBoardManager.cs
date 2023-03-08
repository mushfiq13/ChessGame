namespace ChessGame.Domain;

public interface IBoardManager : IChessBoard
{
    void Add(in IChess item);
    void Set(in IChess item, int targetRank, int targetFile);
    void Remove(int rank, int file);
}
