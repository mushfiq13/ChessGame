using ChessGame.Domain;

namespace ChessGame.Application;

public class GameManager : IGameManager
{
    IGenerateChess _generateChess = Factory.CreateChessCreator();
    IGameServer _gameServer = Factory.CreateGameServer();
    IList<IChess> _whiteChessSet;
    IList<IChess> _blackChessSet;

    public GameManager()
    {
        _whiteChessSet = _generateChess.CreateChessSet(ChessColor.White);
        _blackChessSet = _generateChess.CreateChessSet(ChessColor.Black);
    }

    public void Play()
    {
        AddChessIntoBoard();
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

    private void AddChessIntoBoard()
    {
        foreach (var item in _whiteChessSet)
            Singleton.BoardManager.Add(item);

        foreach (var item in _blackChessSet)
            Singleton.BoardManager.Add(item);
    }

    public void Dispose()
    {
        Singleton.BoardManager = null;
    }
}
