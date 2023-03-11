using ChessGame.Domain;

namespace ChessGame.Application;

public class GameManager : IGameManager
{
    IChessSetCreator _generateChess = Factory.CreateChessSetCreator();
    IGameServer _gameServer = Factory.CreateGameServer();

    public IList<IChess> WhiteChessSet { get; private set; }
    public IList<IChess> BlackChessSet { get; private set; }

    public GameManager()
    {
        WhiteChessSet = _generateChess.Create(ChessColor.White);
        BlackChessSet = _generateChess.Create(ChessColor.Black);
    }

    public void Play()
    {
        SetupChessIntoBoard();
        _gameServer.Run();
        GameCompletionMessages();
    }

    private void GameCompletionMessages()
    {
        if (_gameServer.Winner is not null)
        {
            Singleton.Logger.LogInformation("Congratulations!");
            Singleton.Logger.LogInformation($"{(_gameServer.Winner.Color
                == ChessColor.White ? "White" : "Black")} Chess player won.");
        }
        else
        {
            Singleton.Logger.LogInformation("Unfortunately the game ended with Draw!");
        }

        Singleton.Logger.LogInformation("Closing Application...");
    }

    private void SetupChessIntoBoard()
    {
        foreach (var item in WhiteChessSet)
            Singleton.ChessBoard.Add(item);

        foreach (var item in BlackChessSet)
            Singleton.ChessBoard.Add(item);
    }
}
