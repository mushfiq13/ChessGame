using ChessGame.Domain;

namespace ChessGame.Application;

internal interface ITargetTileCaptureHandler
{
    (int rank, int file) HandleCapturing(IChess sourceTile,
        ChessColor targetTileRestrictedColor);
}