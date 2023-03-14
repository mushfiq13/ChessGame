namespace ChessGame.Domain;

public interface I2DChessMoveable
{
    void Put(int rank, int file);
    bool CanMove(IChess[,] tiles, (int rank, int file) targetTile);
}
