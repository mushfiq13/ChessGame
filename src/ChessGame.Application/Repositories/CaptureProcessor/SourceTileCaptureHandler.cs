using ChessGame.Domain;

namespace ChessGame.Application;

internal class SourceTileCaptureHandler : ISourceTileCaptureHandler
{
    private int _maxCapturingLimit;

    public SourceTileCaptureHandler(int maxCapturingLimit = 1)
    {
        _maxCapturingLimit = maxCapturingLimit;
    }

    public (int rank, int file) HandleCapturing(ChessColor requiredColor)
    {
        bool SourceTileValidator(ChessColor? capturedColor)
            => capturedColor == requiredColor;

        for (var i = 0; i < _maxCapturingLimit; ++i)
        {
            (int rank, int file) = CaptureAndValidate(SourceTileValidator);

            if (rank != -1 && file != -1)
                return (rank, file);

            Singleton.Logger.Log("Try Again!");
        }

        Singleton.Logger.LogWarning($"Your tried {_maxCapturingLimit} time(s).");

        return (-1, -1);
    }

    private (int rank, int file) CaptureAndValidate(Predicate<ChessColor?>? validator)
    {
        (int rank, int file) = Singleton.Capturer.Capture();

        if (rank != -1 && file != -1
            && Singleton.CaptureValidator.Validate(rank, file, validator))
        {
            return (rank, file);
        }

        return (-1, -1);
    }
}
