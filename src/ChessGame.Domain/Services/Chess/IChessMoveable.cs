namespace ChessGame.Domain;

public interface IChessMoveable
{
    void Put(int rank, int file);
    bool CanMove(IChess[,] tiles, (int rank, int file) targetTile);
}
