namespace ChessGame.Domain;

public interface IChessRepository
{
    IChessPiece[,] Tiles { get; }
    (IChessPlayer WhiteChessPlayer, IChessPlayer BlackChessPlayer) Players { get; }
    IChessPlayer CurrentPlayer { get; }
}