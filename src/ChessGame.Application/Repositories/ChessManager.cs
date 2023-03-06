using ChessGame.Domain;

namespace ChessGame.Application;

public partial class ChessManager : IChessManager
{
    public IChessBoard Board { get; private set; } = Factory.CreateChessBoard();
    PieceCommands _pieceCommands;
    PieceQueries _pieceQueries;
    IInputQueries _inputQueries = Factory.CreateInputQueries();
    IInputCommands _inputCommands = Factory.CreateInputCommands();
    IOutputCommands _outputCommands = Factory.CreateOutputCommands();

    public bool IsGameRunning { get; private set; } = false;

    public ChessManager()
    {
        _pieceCommands = Factory.CreatePieceCommands(Board);
    }

    public void Processor()
    {
        Start();

        while (IsGameRunning)
        {
            _outputCommands.DisplayTiles(Board.Tiles);

            (int rank, int file) = _inputCommands.SelecteTile();

            while (_inputQueries.IsTileValid(rank, file) is false)
            {
                (rank, file) = _inputCommands.SelecteTile();
            }

            (int targetRank, int targetFile) = _inputCommands.ChoseTargetTile();

            while (_inputQueries.IsTileValid(targetRank, targetFile) is false)
            {
                (targetRank, targetFile) = _inputCommands.ChoseTargetTile();
            }

            //if (_pieceQueries.IsOpponents(rank, file, targetRank, targetFile))
            //{
            //    continue;
            //}

            //var pieceMoveable = _pieceQueries.IsPieceMoveable(Board.Tiles[rank, file], targetRank, targetFile);

            //if (pieceMoveable is false)
            //{
            //    continue;
            //}

            //if (_pieceQueries.IsOpponents(Board.Tiles[rank, file], targetRank, targetFile))
            //{
            //    _pieceCommands.Kill(Board.Tiles[targetRank, targetFile]);
            //}

            _pieceCommands.Move(Board.Tiles[rank, file], targetRank, targetFile);
        }
    }

    private void Start()
    {
        Setup();
        _outputCommands.DisplayWelcomeMessage();

        IsGameRunning = true;
    }
}
