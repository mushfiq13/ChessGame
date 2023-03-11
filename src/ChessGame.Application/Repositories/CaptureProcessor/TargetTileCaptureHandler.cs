using ChessGame.Domain;

namespace ChessGame.Application;

internal class TargetTileCaptureHandler : ITargetTileCaptureHandler
{
    private int _maxCapturingLimit;

    public TargetTileCaptureHandler(int maxCapturingLimit = 1)
    {
        _maxCapturingLimit = maxCapturingLimit;
    }

    public (int rank, int file) HandleCapturing(IChess sourceTile,
        ChessColor targetTileRestrictedColor)
    {
        bool TargetTileValidator(ChessColor? capturedColor)
            => capturedColor != targetTileRestrictedColor;

        for (var i = 0; i < _maxCapturingLimit; ++i)
        {
            (int rank, int file) = CaptureAndValidate(sourceTile, TargetTileValidator);

            if (rank != -1 && file != -1)
                return (rank, file);

            Singleton.Logger.Log("Try Again!");
        }

        Singleton.Logger.LogWarning($"Your tried {_maxCapturingLimit} time(s).");

        return (-1, -1);
    }

    private (int rank, int file) CaptureAndValidate(IChess sourceChess,
        Predicate<ChessColor?>? validator)
    {
        (int rank, int file) = Singleton.Capturer.Capture();

        if (rank == -1 || file == -1
           || Singleton.CaptureValidator.Validate(rank, file, validator) is false)
        {
            return (-1, -1);
        }

        if (sourceChess.IsMoveable(Singleton.ChessBoard.Tiles, (rank, file)) is false)
        {
            Singleton.Logger.LogError("You can not move to that tile. Invalid choice!");

            return (-1, -1);
        }

        return (rank, file);
    }
}
