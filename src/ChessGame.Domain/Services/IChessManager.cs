namespace ChessGame.Domain;

public interface IChessManager
{
    IChessBoard ChessBoard { get; }
    IBoardGenerator BoardGenerator { get; }
}