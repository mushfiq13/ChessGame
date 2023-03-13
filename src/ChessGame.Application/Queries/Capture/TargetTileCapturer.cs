using ChessGame.ConsoleUI;
using ChessGame.Domain;

namespace ChessGame.Application;

internal class TargetTileCapturer : ITargetTileCapturer
{
    private readonly ILogger _logger;
    private readonly ICaptureHandler _captureHandler;

    public TargetTileCapturer(ILogger logger, ICaptureHandler captureHandler)
    {
        _logger = logger;
        _captureHandler = captureHandler;
    }

    public (int rank, int file) Capture(IChessBoard board, IChess sourceChess, ChessColor movingColor)
    {
        bool customTargetTileValidator(ChessColor? curTileColor)
            => movingColor != curTileColor;

        _logger.Write("\n");
        _logger.LogInformation("Please choose a target tile.\n");

        return _captureHandler.Handle(customTargetTileValidator,
            (target) => sourceChess.IsMoveable(board.Tiles, target));
    }
}
