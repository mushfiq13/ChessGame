namespace ChessGame.Application;

public class ChessApplication : IChessApplication
{
    IAppFactory _appManager;

    public ChessApplication()
    {
        _appManager = new AppFactory();
    }

    public void Run()
    {
        var gameExecutor = _appManager.GameExecutor;
        _appManager.ChessManager
            .BoardGenerator
            .InitializeBoard(_appManager.ChessManager.ChessBoard);

        gameExecutor.Play();
    }
}

