using ChessGame.ConsoleUI;
using ChessGame.Domain;

namespace ChessGame.Application;

internal class CaptureHandler : ICaptureHandler
{
    private readonly ILogger _logger;
    private readonly ICaptureData _capture;
    private readonly ICaptureValidator _validator;

    public CaptureHandler(ILogger logger, ICaptureData capture, ICaptureValidator validator)
    {
        _logger = logger;
        _capture = capture;
        _validator = validator;
    }

    public (int rank, int file) Handle(
        Predicate<ChessColor?>? customValidator,
        Predicate<(int, int)>? moveChecker)
    {
        (int rank, int file) = _capture.Capture();

        if (rank != -1 && file != -1
            && _validator.Validate(rank, file, customValidator))
        {
            if (moveChecker is null || moveChecker((rank, file)) == true)
                return (rank, file);

            _logger.LogError("You move is invalid!");
        }

        return (-1, -1);
    }
}

