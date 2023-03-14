namespace ChessGame.Domain;

public interface IChessServiceProvider
{
    IChessBoard CreateChessBoard();
    void AddChesses(ref IChessBoard board);
}