namespace ChessGame.Domain;

public interface IChessBoard
{
    IChess[,] Tiles { get; }
}
