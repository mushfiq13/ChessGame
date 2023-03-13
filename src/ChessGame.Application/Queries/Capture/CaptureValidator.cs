using ChessGame.ConsoleUI;
using ChessGame.Domain;

namespace ChessGame.Application;

internal class CaptureValidator : ICaptureValidator
{
    private readonly ILogger _logger;
    private readonly IChessBoard _board;

    public CaptureValidator(ILogger logger, IChessBoard board)
    {
        _logger = logger;
        _board = board;
    }

    public bool Validate(int rank, int file, Predicate<ChessColor?>? validator)
    {
        try
        {
            if (Inbound(rank, file) is false)
                throw new InvalidDataException();

            if (validator is not null
                && validator(_board[rank, file]?.Color) is false)
                throw new InvalidDataException();

            return true;
        }
        catch
        {
            _logger.LogError("Location is not valid!");
        }

        return false;
    }

    private bool Inbound(int? rank, int? file)
        => rank >= 0 && file >= 0
            && rank < 8 && file < 8;
}
