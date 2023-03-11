using ChessGame.Domain;

namespace ChessGame.Application;

internal class CaptureProcessor : ICaptureProcessor
{
    ISourceTileCaptureHandler _sourceTileCaptureHandler
        = Factory.CreateSourceTileCaptureHandler(3);
    ITargetTileCaptureHandler _targetTileCaptureHandler
        = Factory.CreateTargetTileCaptureHandler(3);

    public (IChess sourceChess, (int rank, int file) targetTile) Run(ChessColor movingColor)
    {
        Singleton.Logger.Write("\n");
        Singleton.Logger.LogInformation("Please choose a moveable chess.\n");
        var sourceTile = _sourceTileCaptureHandler.HandleCapturing(movingColor);

        if (sourceTile.rank == -1 || sourceTile.file == -1)
            return (null, (-1, -1));

        var sourceChess = Singleton.ChessBoard[sourceTile.rank, sourceTile.file];

        Singleton.Logger.Write("\n");
        Singleton.Logger.LogInformation("Please choose a target tile.\n");
        var targetTile = _targetTileCaptureHandler.HandleCapturing(sourceChess, movingColor);

        return (sourceChess, targetTile);
    }
}
