using ChessGame.Domain;

namespace ChessGame.Application;

internal interface ITargetTileCapturer
{
    (int rank, int file) Capture(IChessBoard board, IChess sourceChess, ChessColor movingColor);
}