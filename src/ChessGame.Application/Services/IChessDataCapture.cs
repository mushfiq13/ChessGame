using ChessGame.Domain;

namespace ChessGame.Application;

internal interface IChessDataCapture
{
    (IChess source, (int rank, int file) target)? Capture(ChessColor sourceColor);
}