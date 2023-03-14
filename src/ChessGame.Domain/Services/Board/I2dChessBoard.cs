namespace ChessGame.Domain;

public interface I2dChessBoard
{
    IChess[,] Tiles { get; }

    IChess this[int rank, int file] { get; }

    void Put(IChess item, int rank, int file);
    void Remove(int rank, int file);
}
