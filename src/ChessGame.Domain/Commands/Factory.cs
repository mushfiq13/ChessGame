namespace ChessGame.Domain;

internal class Factory : IFactory
{
    private static readonly IFactory _instance = new Factory();
    private readonly IBoardSetup _boardSetup = BoardSetup.GetBoardSetup();

    private Factory()
    {
    }

    public static IFactory GetServices()
    {
        return _instance;
    }

    public IChessBoard CreateChessBoard() => new ChessBoard();

    public IBoardSetup GetBoardSetup() => _boardSetup;
}
