namespace ChessGame.Domain;

public interface IChessBoard
{
    IChess[,] Tiles { get; }

    IChess this[int rank, int file] { get; }

    IChessBoard Add(in IChess item);
    IChessBoard Add(in IChess item, int rank, int file);
    IChessBoard Remove(int rank, int file);

    void Clear();
}
