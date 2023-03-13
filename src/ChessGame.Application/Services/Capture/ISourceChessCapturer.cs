using ChessGame.Domain;

namespace ChessGame.Application;

internal interface ISourceChessCapturer
{
    IChess Capture(IChessBoard board, ChessColor movingColor);
}