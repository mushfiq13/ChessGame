using ChessGame.Domain;

namespace ChessGame.Application;

internal interface ISourceTileCaptureHandler
{
    (int rank, int file) HandleCapturing(ChessColor requiredColor);
}