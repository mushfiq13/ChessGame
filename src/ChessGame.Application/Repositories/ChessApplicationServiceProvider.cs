using ChessGame.ConsoleUI;
using ChessGame.Domain;

namespace ChessGame.Application;

public class ChessApplicationServiceProvider : IChessApplicationServiceProvider
{
    private readonly IFactory _factory = default;

    public ChessApplicationServiceProvider()
    {
        _factory = new Factory(
            ChessServiceProvider.GetServices(),
            ConsoleServiceProvider.GetServices());
    }

    public void Run()
    {
        var board = _factory.CreateChessBoardInstance();

        ChessServiceProvider.GetServices()
            .AddChesses(ref board);

        var executor = _factory.GetGameExecutorInstance(board);

        executor.Play();
    }
}