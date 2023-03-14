namespace ChessGame.Domain;

public interface IChess : IBoard2D, IChessMoveable
{
    ChessColor Color { get; }
    string Unicode { get; }

    void Kill();
}