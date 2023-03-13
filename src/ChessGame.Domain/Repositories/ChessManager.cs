namespace ChessGame.Domain;

public class ChessManager : IChessManager
{
    IFactory _factory;

    public IChessBoard ChessBoard { get; }
    public IBoardGenerator BoardGenerator { get; }

    public ChessManager()
    {
        _factory = new Factory();
        ChessBoard = _factory.CreateChessBoard();
        BoardGenerator = _factory.CreateBoardGenerator();
    }
}
