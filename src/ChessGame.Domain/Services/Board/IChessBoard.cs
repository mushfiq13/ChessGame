namespace ChessGame.Domain;

public interface IChessBoard
{
    IChess[,] Tiles { get; }

    IChess this[int rank, int file] { get; }

    IChessBoard Add(params IChess[] item);
    IChessBoard Put(IChess item, int rank, int file);
    void Remove(int rank, int file);

    void Clear();
}
