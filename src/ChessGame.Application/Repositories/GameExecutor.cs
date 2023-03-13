using ChessGame.ConsoleUI;
using ChessGame.Domain;

namespace ChessGame.Application;

internal class GameExecutor : IGameExecutor
{
    private readonly IChessManager _chessManager;
    private readonly IConsoleUIManager _uIManager;
    private readonly ICaptureProcessor _captureProcessor;
    private readonly IChessHandler _chessHandler;
    private readonly IOutputHandler _outputHandler;

    public IList<IChess> Captured { get; private set; } = new List<IChess>();
    public bool WhiteInTurn { get; private set; } = true;
    public IChessBase? Winner { get; private set; }

    public GameExecutor(
        IChessManager chessManager,
        IConsoleUIManager uIManager,
        ICaptureProcessor captureProcessor,
        IChessHandler chessHandler,
        IOutputHandler outputHandler)
    {
        _chessManager = chessManager;
        _uIManager = uIManager;
        _captureProcessor = captureProcessor;
        _chessHandler = chessHandler;
        _outputHandler = outputHandler;
    }

    public void Play()
    {
        while (true)
        {
            var movingColor = WhiteInTurn ? ChessColor.White : ChessColor.Black;

            _outputHandler.DisplayOutput(movingColor,
                _chessManager.ChessBoard.Tiles,
                Captured.ToArray());

            var capturedData = _captureProcessor.Process(movingColor);
            var sourceChess = capturedData.sourceChess;
            var targetTile = capturedData.targetTile;

            if (targetTile.rank == -1 || targetTile.file == -1)
            {
                return;
            }

            var killedItem = _chessHandler.HandleCurrentTurn(sourceChess,
                targetTile.rank,
                targetTile.file);

            if (killedItem is not null)
            {
                Captured.Add(killedItem);
            }
            //Winner = ChessDataGetter.IsKingsUnicode(targetChess?.Unicode)
            //    ? sourceChess : null;

            TogglePlayer();
            _uIManager.Logger.Log("\nUpdating...");
            Thread.Sleep(1 * 2000);
            _uIManager.ConsoleOutput.ResetConsole();
        }
    }

    private void TogglePlayer() => WhiteInTurn = !WhiteInTurn;
}
