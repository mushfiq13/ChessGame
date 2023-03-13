namespace ChessGame.Domain;

public interface IChess : IChessBase
{
    void Kill();
    void Put(int rank, int file);
    bool CanMove(IChessBase[,] tiles, (int rank, int file) targetTile);
}