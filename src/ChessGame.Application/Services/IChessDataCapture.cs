using ChessGame.Domain;

namespace ChessGame.Application;

internal interface IChessDataCapture
{
    (IChess source, (int rank, int file) target) Capture(
        IChess[,] tiles,
        ChessColor sourceColor);
}