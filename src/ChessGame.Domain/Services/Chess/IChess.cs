namespace ChessGame.Domain;

public interface IChess : IChessLocation, I2DChessMoveable
{
    ChessColor Color { get; }
    string Unicode { get; }

    void Kill();
}