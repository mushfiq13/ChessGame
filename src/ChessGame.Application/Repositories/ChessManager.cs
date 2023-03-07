using ChessGame.Domain;

namespace ChessGame.Application;

public partial class ChessManager : IChessManager
{
    ChessColor _currentPlayerColor = ChessColor.White;
    int _currentPlayerTriedToMove = 0;

    IChessBoard Board = Factory.CreateChessBoard();
    IInputQueries _inputQueries = Factory.CreateInputQueries();
    IInputCommands _inputCommands = Factory.CreateInputCommands();
    IOutputCommands _outputCommands = Factory.CreateOutputCommands();
    IChessQueries _chessQueries = Factory.CreateChessQueries();
    IPieceCommands _pieceCommands;

    public bool IsGameRunning { get; private set; } = false;

    public ChessManager()
    {
        _pieceCommands = Factory.CreatePieceCommands(Board);
    }

    public void Processor()
    {
        Start();
        Run();
    }

    private void Start()
    {
        Setup();

        IsGameRunning = true;

        _outputCommands.WriteMessage("Welcome To Chess Game :)");
    }

    private void Run()
    {
        while (IsGameRunning)
        {
            _outputCommands.DrawTiles(Board.Tiles);

            if (_currentPlayerColor == ChessColor.White)
            {
                _outputCommands.WriteMessage("\n  -> White Chess can be moved.\n");
            }
            else
            {
                _outputCommands.WriteMessage("\n  -> Black Chess can be moved.\n");
            }

            (int srcRank, int srcFile, int targetRank, int targetFile) = AskUser();

            if (Board.Tiles[srcRank, srcFile]?.Color != _currentPlayerColor)
            {
                _outputCommands.ResetConsole();
                _outputCommands.WriteMessage("WARNING! you did not selected your piece! Try Again.");
                Thread.Sleep(100);
                continue;
            }

            var targetHasKing = _chessQueries.IsKing(Board.Tiles[targetRank, targetFile]);

            var success = _pieceCommands.Move(Board.Tiles[srcRank, srcFile], targetRank, targetFile);

            if (success == false)
            {
                _outputCommands.WriteMessage("\nSorry, your piece can not go to target tile!");
                _outputCommands.WriteMessage("Try Again :)");

                ++_currentPlayerTriedToMove;
            }
            else
            {
                if (targetHasKing)
                {
                    _outputCommands.WriteMessage("\nHurray! You won the game...\n");
                    IsGameRunning = false;

                    break;
                }

                _currentPlayerColor = _currentPlayerColor == ChessColor.White
                    ? ChessColor.Black : ChessColor.White;

                _currentPlayerTriedToMove = 0;

                _outputCommands.ResetConsole();
                Thread.Sleep(100);
            }

            if (_currentPlayerTriedToMove >= 50)
            {
                _outputCommands.WriteMessage($"You tried for last {_currentPlayerTriedToMove} times. You lost the game.");
                IsGameRunning = false;
            }
        }
    }

    public void Dispose()
    {
        Board = null;
        _inputCommands = null;
        _inputQueries = null;
        _outputCommands = null;
        _pieceCommands = null;
        _chessQueries = null;
    }
}
