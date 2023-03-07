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

            (int srcRank, int srcFile, int targetRank, int targetFile) = AskUser();

            var success = _pieceCommands.Move(Board.Tiles[srcRank, srcFile], targetRank, targetFile);

            if (success == false)
            {
                _outputCommands.WriteMessage("Sorry, your piece can not go to target tile!");
                _outputCommands.WriteMessage("Try Again :)");

                ++_currentPlayerTriedToMove;
            }
            else
            {
                _currentPlayerColor = _currentPlayerColor == ChessColor.White
                    ? ChessColor.Black : ChessColor.White;

                _currentPlayerTriedToMove = 0;
            }

            if (_currentPlayerTriedToMove >= 50)
            {
                _outputCommands.WriteMessage($"Hurray Winned!");
            }
        }
    }
}
