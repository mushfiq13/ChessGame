namespace ChessGame.Domain;

public class ChessServiceProvider : IChessServiceProvider
{
    private static readonly IChessServiceProvider _instance = new ChessServiceProvider();
    private readonly IFactory _factory = Factory.GetServices();

    private ChessServiceProvider()
    {
    }

    public static IChessServiceProvider GetServices()
    {
        return _instance;
    }

    public IChessBoard CreateChessBoard()
    {
        return _factory.CreateChessBoard();
    }

    public void AddChesses(ref IChessBoard board)
    {
        _factory.GetBoardSetup()
            .AddChesses(ref board);
    }
}
