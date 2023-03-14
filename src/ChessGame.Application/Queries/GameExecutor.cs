using ChessGame.ConsoleUI;
using ChessGame.Domain;

namespace ChessGame.Application;

internal class GameExecutor : IGameExecutor
{
    private readonly IChessBoard _board;
    private readonly IConsoleOutput _consoleOutput;
    private readonly ICaptureProcessor _captureProcessor;
    private readonly IChessHandler _chessHandler;
    private readonly IOutputHandler _outputHandler;

    public IList<IChess> Captured { get; private set; } = new List<IChess>();
    public bool WhiteInTurn { get; private set; } = true;
    public IBoard2D? Winner { get; private set; }

    public GameExecutor(
        IChessBoard board,
        IConsoleOutput consoleOutput,
        ICaptureProcessor captureProcessor,
        IChessHandler chessHandler,
        IOutputHandler outputHandler)
    {
        _board = board;
        _consoleOutput = consoleOutput;
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
                _board.Tiles,
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
            _consoleOutput.Write("\nUpdating...\n");
            Thread.Sleep(1 * 2000);
            _consoleOutput.ResetConsole();
        }
    }

    private void TogglePlayer() => WhiteInTurn = !WhiteInTurn;
}
