using ChessGame.ConsoleUI;
using ChessGame.Domain;

namespace ChessGame.Application;

internal class Factory : IFactory
{
    private readonly IConsoleServiceProvider _consoleServices;

    private IGameExecutor _gameExecutor = default;
    private IChessHandler _chessHandler = default;
    private IOutputHandler _outputHandler = default;
    private ICaptureProcessor _captureProcessor = default;

    public Factory(IConsoleServiceProvider consoleServices)
    {
        _consoleServices = consoleServices;
    }

    public IGameExecutor GetGameExecutorInstance(IChessBoard board)
    {
        if (_gameExecutor == null)
        {
            _gameExecutor = new GameExecutor(board,
                _consoleServices.GetConsoleOutput(),
                GetCaptureProcessorInstance(board),
                GetChessHandlerInstance(board),
                GetOutputHandlerInstance());
        }

        return _gameExecutor;
    }

    public IChessHandler GetChessHandlerInstance(IChessBoard board)
    {
        if (_chessHandler is not null) return _chessHandler;

        return _chessHandler = new ChessHandler(board);
    }

    public IOutputHandler GetOutputHandlerInstance()
    {
        if (_outputHandler is not null) return _outputHandler;

        return _outputHandler = new OutputHandler(_consoleServices.GetConsoleOutput());
    }

    public ICaptureProcessor GetCaptureProcessorInstance(IChessBoard board)
    {
        if (_captureProcessor is not null)
            return _captureProcessor;

        var captureHandler = CreateCaptureHandlerInstance(board);
        var sourceCapturer = CreateSourceChessCapturerInstance(captureHandler);
        var targetCapturer = CreateTargetCapturerInstance(captureHandler);

        return _captureProcessor = new CaptureProcessor(board,
                 sourceCapturer,
                 targetCapturer);
    }

    private ISourceChessCapturer CreateSourceChessCapturerInstance(ICaptureHandler captureHandler)
        => new SourceChessCapturer(_consoleServices.GetLogger(), captureHandler);

    private ITargetTileCapturer CreateTargetCapturerInstance(ICaptureHandler captureHandler)
        => new TargetTileCapturer(_consoleServices.GetLogger(), captureHandler);

    private ICaptureHandler CreateCaptureHandlerInstance(IChessBoard board)
        => new CaptureHandler(_consoleServices.GetLogger(),
           CreateCaptureDataInstance(),
           CreateCaptureValidatorInstance(board));

    private ICaptureData CreateCaptureDataInstance()
        => new CaptureData(_consoleServices.GetLogger(),
            _consoleServices.GetConsoleInput(),
            _consoleServices.GetConsoleOutput());

    private ICaptureValidator CreateCaptureValidatorInstance(IChessBoard board)
        => new CaptureValidator(_consoleServices.GetLogger(), board);
}
