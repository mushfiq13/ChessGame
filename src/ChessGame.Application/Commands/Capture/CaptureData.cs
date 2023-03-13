using ChessGame.ConsoleUI;

namespace ChessGame.Application;

internal class CaptureData : ICaptureData
{
    private readonly ILogger _logger;
    private readonly IConsoleInput _consoleInput;

    public CaptureData(ILogger logger, IConsoleInput consoleInput)
    {
        _logger = logger;
        _consoleInput = consoleInput;
    }

    public (int, int) Capture()
    {
        try
        {
            _logger.Write("Enter rank: ");
            var rank = ReadAndExtractDigit();

            _logger.Write("Enter file: ");
            var file = ReadAndExtractDigit();

            return (rank, file);
        }
        catch
        {
            _logger.LogError("Could not get any valid data!");
        }

        return (-1, -1);
    }

    private int ReadAndExtractDigit()
    {
        var input = _consoleInput.Reader();
        var charArray = input?.Trim().ToCharArray();

        if (charArray?.Length == 1)
            return charArray[0] - '0';

        throw new InvalidDataException();
    }
}
