using ChessGame.ConsoleUI;
using ChessGame.Domain;

namespace ChessGame.Application;

internal class SourceChessCapturer : ISourceChessCapturer
{
    private readonly ILogger _logger;
    private readonly ICaptureHandler _captureHandler;

    public SourceChessCapturer(ILogger logger, ICaptureHandler captureHandler)
    {
        _logger = logger;
        _captureHandler = captureHandler;
    }

    public IChess Capture(IChessBoard board, ChessColor movingColor)
    {
        bool customSourceTileValidator(ChessColor? curTileColor)
            => movingColor == curTileColor;

        _logger.LogInformation("Please choose a moveable chess.\n");

        var sourceTile = _captureHandler.Handle(customSourceTileValidator, null);

        if (sourceTile.rank != -1 && sourceTile.file != -1)
            return board[sourceTile.rank, sourceTile.file];

        return null;
    }
}
