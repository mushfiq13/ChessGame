namespace ChessGame.Domain;

public class ChessManager : IChessManager
{
    IFactory _factory = new Factory();

    public IChessBoard ChessBoard { get; }
    public IBoardGenerator BoardGenerator { get; }

    public ChessManager()
    {
        ChessBoard = _factory.GetChessBoard();
        BoardGenerator = _factory.GetBoardGenerator();
    }
}
