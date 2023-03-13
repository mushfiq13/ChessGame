using ChessGame.Domain;

namespace ChessGame.Application;

internal class CaptureProcessor : ICaptureProcessor
{
    private readonly IChessBoard _board;
    private readonly ISourceChessCapturer _sourceCapturer;
    private readonly ITargetTileCapturer _targetCapturer;

    public CaptureProcessor(IChessBoard board, ISourceChessCapturer sourceCapturer, ITargetTileCapturer targetCapturer)
    {
        _board = board;
        _sourceCapturer = sourceCapturer;
        _targetCapturer = targetCapturer;
    }

    public (IChess sourceChess, (int rank, int file) targetTile) Process(ChessColor movingColor)
    {
        var sourceChess = _sourceCapturer.Capture(_board, movingColor);

        if (sourceChess is null)
            return (null, (-1, -1));

        var targetTile = _targetCapturer.Capture(_board, sourceChess, movingColor);

        return (sourceChess, targetTile);
    }
}
