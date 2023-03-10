namespace ChessGame.Domain;

public interface IBoardManager : IChessBoard
{
    IBoardManager Add(in IChess item);
    IBoardManager SetTo(in IChess item, int newRank, int newFile);
    IBoardManager Remove(int rank, int file);
    void Clear();
}
