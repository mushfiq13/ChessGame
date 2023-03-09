namespace ChessGame.Domain;

public interface IBoardManager : IChessBoard
{
    void Add(in IChess item);
    void SetTo(in IChess item, int newRank, int newFile);
    void Remove(int rank, int file);
    void Clear();
}
