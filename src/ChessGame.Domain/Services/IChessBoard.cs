namespace ChessGame.Domain;

public interface IChessBoard
{
    IChessCore[,] Tiles { get; }
}