using ChessGame.ConsoleUI;
using ChessGame.Domain;

namespace ChessGame.Application;

internal class AppFactory : IAppFactory
{
    public IGameExecutor GameExecutor { get; }
    public ICaptureProcessor CaptureProcessor { get; }
    public IChessHandler ChessHandler { get; }
    public IOutputHandler OutputHandler { get; }
    public IChessManager ChessManager { get; }
    public IConsoleUIManager ConsoleUIManager { get; }

    public AppFactory()
    {
        ChessManager = new ChessManager();
        ConsoleUIManager = new ConsoleUIManager();

        CaptureProcessor = CreateCaptureProcessor();
        ChessHandler = CreateChessHandler();
        OutputHandler = CreateOutputHandler();

        GameExecutor = CreateGameExecutor();
    }

    private IGameExecutor CreateGameExecutor()
        => new GameExecutor(ChessManager,
            ConsoleUIManager,
            CaptureProcessor,
            ChessHandler,
            OutputHandler);

    private IChessHandler CreateChessHandler()
        => new ChessHandler(ChessManager.ChessBoard);

    private ICaptureProcessor CreateCaptureProcessor()
    {
        ICaptureFactory captureFactory = CreateCaptureFactory();

        return captureFactory.CreateCaptureProcessor();
    }

    private IOutputHandler CreateOutputHandler()
        => new OutputHandler(ConsoleUIManager.ConsoleOutput);

    private ICaptureFactory CreateCaptureFactory()
    {
        return new CaptureFactory(ConsoleUIManager.Logger,
                ChessManager.ChessBoard,
                ConsoleUIManager.ConsoleInput);
    }
}
