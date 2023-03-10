using ChessGame.Domain;

namespace ChessGame.Application;

public class GameManager : IGameManager
{
    IGenerateChess _generateChess = Factory.CreateChessCreator();
    IGameServer _gameServer = Factory.CreateGameServer();

    public IList<IChess> WhiteChessSet { get; private set; }
    public IList<IChess> BlackChessSet { get; private set; }

    public GameManager()
    {
        WhiteChessSet = _generateChess.CreateChessSet(ChessColor.White);
        BlackChessSet = _generateChess.CreateChessSet(ChessColor.Black);
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
            Singleton.ConsoleMessages.WriteMessage("\n\nCongratulations!");
            Singleton.ConsoleMessages.WriteMessage($"{(_gameServer.Winner.Color
                == ChessColor.White ? "White" : "Black")} Chess player won.");
        }
        else
        {
            Singleton.ConsoleMessages.WriteMessage("\n\nUnfortunately the game ended with Draw!");
        }

        Singleton.ConsoleMessages.WriteMessage("Closing Application...");
        Singleton.ConsoleMessages.EndApplication();
    }

    private void SetupChessIntoBoard()
    {
        foreach (var item in WhiteChessSet)
            Singleton.ChessBoard.Add(item);

        foreach (var item in BlackChessSet)
            Singleton.ChessBoard.Add(item);
    }
}
