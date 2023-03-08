using ChessGame.Domain;

namespace ChessGame.Application;

public partial class GameManager : IGameManager
{
    IBoardManager _board = Factory.CreateBoardManager();
    StandardMessages _messages = Factory.CreateStandardMessages();
    IGameCommands _chessCommands = Factory.CreatePieceCommands();
    IConsoleUICommands _UICommands = Factory.CreateConsoleUICommands();

    int _currentPlayerTriedToMove = 0;
    IList<IChessCore> _whiteCaptured = new List<IChessCore>();
    IList<IChessCore> _blackCaptured = new List<IChessCore>();

    public ChessColor? CurrentPlayer { get; private set; }
    public ChessColor? Winner { get; private set; }

    public GameManager()
    {
        ChessGenerator.AddEntireChessSet(_board, ChessColor.White);
        ChessGenerator.AddEntireChessSet(_board, ChessColor.Black);

        CurrentPlayer = ChessColor.White;

        _messages.WelcomeMessage();
    }

    public void Play()
    {
        if (CurrentPlayer is null)
            throw new InvalidOperationException();

        while (Over())
        {
            _UICommands.DrawLogo();
            _UICommands.DisplayMenu();
            _UICommands.DisplayCapturedItems(_whiteCaptured.ToArray(), _blackCaptured.ToArray());
            _UICommands.DrawTiles(_board.Tiles);
            _UICommands.CurrentTurn(CurrentPlayer == ChessColor.White ? "White" : "Black");

            (int srcRank, int srcFile, int targetRank, int targetFile) = Capture();

            if (_board.Tiles[srcRank, srcFile]?.Color != CurrentPlayer)
            {
                _UICommands.ResetConsole();
                //_outputCommands.WriteMessage("WARNING! you did not selected your piece! Try Again.");

                Thread.Sleep(100);
                continue;
            }

            var targetHasKing = _board.Tiles[targetRank, targetFile]?.Unicode == "\u2654" || _board.Tiles[targetRank, targetFile]?.Unicode == "\u265A";

            var success = _chessCommands.Move(_board, _board.Tiles[srcRank, srcFile], targetRank, targetFile);

            if (success == false)
            {
                //_outputCommands.WriteMessage("\nSorry, your piece can not go to target tile!");
                //_outputCommands.WriteMessage("Try Again :)");

                ++_currentPlayerTriedToMove;
            }
            else
            {
                if (targetHasKing)
                {
                    //_outputCommands.WriteMessage("\nHurray! You won the game...\n");
                    Winner = CurrentPlayer;

                    break;
                }

                CurrentPlayer = CurrentPlayer == ChessColor.White
                    ? ChessColor.Black : ChessColor.White;

                _currentPlayerTriedToMove = 0;

                _UICommands.ResetConsole();
                Thread.Sleep(100);
            }

            if (_currentPlayerTriedToMove >= 50)
            {
                // _outputCommands.WriteMessage($"You tried for last {_currentPlayerTriedToMove} times. You lost the game.");
                Winner = CurrentPlayer == ChessColor.White
                    ? ChessColor.Black : ChessColor.White;
            }
        }
    }

    public void Replay()
    {
        throw new NotImplementedException();
    }

    public bool Over() => Winner is null;

    public void Dispose()
    {
        _board = null;
        _chessCommands = null;
        _messages = null;
        _UICommands = null;
    }
}
