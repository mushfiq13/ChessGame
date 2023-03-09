using ChessGame.Domain;

namespace ChessGame.Application;

public class GameManager : IGameManager
{
    public void Play()
    {
        IGenerateChess generateChess = Factory.CreateChessCreator();
        generateChess.CreateChessSet(ChessColor.White);
        generateChess.CreateChessSet(ChessColor.Black);

        using IGameServer _gameServer = Factory.CreateGameServer();

        _gameServer.Run();

        if (_gameServer.Winner is not null)
        {
            Singleton.ConsoleMessages.WriteMessage("\n\nCongratulations!");
            Singleton.ConsoleMessages.WriteMessage($"{(_gameServer.Winner.Color
                == ChessColor.White ? "White" : "Black")} Chess player won.");
        }

        Singleton.ConsoleMessages.WriteMessage("Closing Application...");
        Singleton.ConsoleManager.Messager.EndApplication();
    }
}
