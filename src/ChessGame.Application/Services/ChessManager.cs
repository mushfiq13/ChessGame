namespace ChessGame.Application;

public class ChessManager : IChessManager
{
    IChessRepositoryManager _repositoryManager;
    IPieceCommands _pieceCommands;
    IPieceQueries _pieceQueries;
    IInputQueries _inputQueries;
    IInputCommands _inputCommands;
    IOutputCommands _outputCommands;

    public bool IsGameRunning { get; private set; } = false;

    public ChessManager()
    {
        _repositoryManager = Factory.CreateChessRepository();
        _pieceCommands = Factory.CreatePieceCommands(_repositoryManager);
        _inputQueries = Factory.CreateInputQueries();
        _pieceQueries = Factory.CreatePieceQueries(_repositoryManager.Tiles);
        _inputCommands = Factory.CreateInputCommands();
        _outputCommands = Factory.CreateOutputCommands();
    }

    public void Processor()
    {
        Start();

        while (IsGameRunning)
        {
            _outputCommands.DisplayTiles(_repositoryManager.Tiles);

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

            if (_pieceQueries.IsPlayersChoiceValid(rank, file, targetRank, targetFile) is false)
            {
                continue;
            }

            var pieceMoveable = _pieceQueries.IsPieceMoveable(_repositoryManager.Tiles[rank, file], targetRank, targetFile);

            if (pieceMoveable is false)
            {
                continue;
            }

            if (_pieceQueries.IsOpponentsPiece(_repositoryManager.Tiles[rank, file], targetRank, targetFile))
            {
                _pieceCommands.KillPiece(_repositoryManager.Tiles[targetRank, targetFile]);
            }

            _pieceCommands.MovePiece(_repositoryManager.Tiles[rank, file], targetRank, targetFile);

            _repositoryManager.TogglePlayer();
        }
    }

    private void Start()
    {
        _outputCommands.DisplayWelcomeMessage();

        IsGameRunning = true;
    }
}
