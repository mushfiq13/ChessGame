using ChessGame.ConsoleUI;
using ChessGame.Domain;

namespace ChessGame.Application;

public class ApplicationServiceProvider : IApplicationServiceProvider
{
    private readonly IFactory _factory = default;

    public ApplicationServiceProvider()
    {
        _factory = new Factory(ConsoleServiceProvider.GetServices());
    }

    public void Run()
    {
        var board = ChessServiceProvider.GetServices()
            .CreateChessBoard();

        ChessServiceProvider.GetServices()
            .AddChesses(ref board);

        var executor = _factory.GetGameExecutorInstance(board);

        executor.Play();
    }
}