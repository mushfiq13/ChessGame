using ChessGame.Domain;

namespace ChessGame.Application;

public partial class GameManager : IGameManager
{
    IBoardManager _boardManager = Factory.CreateBoardManager();
    IGameCommands _chessCommands = Factory.CreatePieceCommands();
    IConsoleUICommands _UICommands = Factory.CreateConsoleUICommands();

    IList<IChessCore> _whiteCaptured = new List<IChessCore>();
    IList<IChessCore> _blackCaptured = new List<IChessCore>();

    public ChessColor? CurrentPlayer { get; private set; }
    public ChessColor? Winner { get; private set; }

    public GameManager()
    {
        ChessGenerator.CreateChessSet(_boardManager, ChessColor.White);
        ChessGenerator.CreateChessSet(_boardManager, ChessColor.Black);

        CurrentPlayer = ChessColor.White;
    }

    public void Replay()
    {
        throw new NotImplementedException();
    }

    public bool Over() => Winner is not null;

    public void Play()
    {
        if (CurrentPlayer is null)
            throw new InvalidOperationException();

        while (Over() is false)
        {
            _UICommands.DrawLogo();
            _UICommands.DrawTiles(_boardManager.Tiles);
            _UICommands.DisplayMenu();
            _UICommands.DisplayCapturedItems(_whiteCaptured.ToArray(), _blackCaptured.ToArray());
            _UICommands.DisplayCurrentTurn(CurrentPlayer == ChessColor.White ? "White" : "Black");

            (int srcRank, int srcFile) = _UICommands.CaptureChess();
            (int targetRank, int targetFile) = _UICommands.CaptureChess();

            var success = _chessCommands.Move(_boardManager, _boardManager.Tiles[srcRank, srcFile], targetRank, targetFile);

            if (success)
                TogglePlayer();
            else
                _UICommands.DisplayMessage("\n\nYour selection is not valid. Try Again!");

            _UICommands.ResetConsole();

            Thread.Sleep(100);
        }
    }

    private void TogglePlayer()
        => CurrentPlayer = CurrentPlayer == ChessColor.White
                    ? ChessColor.Black : ChessColor.White;

    public void Dispose()
    {
        _boardManager = null;
        _chessCommands = null;
        _UICommands = null;
    }
}
