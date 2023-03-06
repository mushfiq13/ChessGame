namespace ChessGame.Domain;

public interface IChessRepository
{
    IChess[,] Tiles { get; }
}