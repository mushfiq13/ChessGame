namespace ChessGame.Domain;

public interface IBoardManager : IChessBoard
{
    void Add(in IChess item);
    void Remove(int rank, int file);
}
