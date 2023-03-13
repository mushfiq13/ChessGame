using ChessGame.ConsoleUI;
using ChessGame.Domain;

namespace ChessGame.Application;

internal class CaptureFactory : ICaptureFactory
{
    private readonly ILogger _logger;
    private readonly IChessBoard _board;
    private readonly IConsoleInput _consoleInput;

    private ICaptureHandler _captureHandler = default;

    public CaptureFactory(ILogger logger, IChessBoard board, IConsoleInput consoleInput)
    {
        _logger = logger;
        _board = board;
        _consoleInput = consoleInput;
    }

    public ICaptureProcessor CreateCaptureProcessor()
    {
        return new CaptureProcessor(_board,
                 CreateSourceChessCapturer(),
                 CreateTargetCapturer());
    }

    private ISourceChessCapturer CreateSourceChessCapturer()
        => new SourceChessCapturer(_logger, CreateCaptureHandler());

    private ITargetTileCapturer CreateTargetCapturer()
        => new TargetTileCapturer(_logger, CreateCaptureHandler());

    private ICaptureHandler CreateCaptureHandler()
    {
        if (_captureHandler == null)
        {
            _captureHandler = new CaptureHandler(_logger,
                CreateCaptureData(),
                CreateCaptureValidator());
        }

        return _captureHandler;
    }

    private ICaptureData CreateCaptureData()
        => new CaptureData(_logger, _consoleInput);

    private ICaptureValidator CreateCaptureValidator()
        => new CaptureValidator(_logger, _board);
}
