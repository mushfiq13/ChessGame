namespace ChessGame.Domain;

public interface IChessBoard
{
    IChessPiece[,] Tiles { get; }
}