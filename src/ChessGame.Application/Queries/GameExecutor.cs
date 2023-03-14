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
    public bool? WhiteInTurn { get; private set; } = null;
    public IChess? Winner { get; private set; }

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
        WhiteInTurn = true;

        while (true)
        {
            var movingColor = (bool)WhiteInTurn ? ChessColor.White : ChessColor.Black;

            _outputHandler.DisplayOutput(movingColor,
                _board.Tiles,
                Captured.ToArray());

            (IChess sourceChess, (int tarRank, int tarFile)) = _captureProcessor.Process(movingColor);

            if (tarRank == -1 || tarFile == -1)
            {
                break;
            }

            var killedItem = _chessHandler.HandleCurrentTurn(sourceChess,
                tarRank,
                tarFile);

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

        WhiteInTurn = null;
    }

    private void TogglePlayer() => WhiteInTurn = !WhiteInTurn;
}
