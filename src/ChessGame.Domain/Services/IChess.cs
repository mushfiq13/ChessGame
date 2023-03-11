namespace ChessGame.Domain;

public interface IChess : IChessCore
{
    void Kill();
    void Put(int rank, int file);
    bool IsMoveable(IChessCore[,] tiles, (int rank, int file) targetTile);
}