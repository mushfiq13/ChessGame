namespace ChessGame.Domain;

internal class Factory : IFactory
{
    public IChessBoard CreateChessBoard() => new ChessBoard();

    public IBoardGenerator CreateBoardGenerator()
        => new BoardGenerator(CreateChessFactory());

    public IChessValidator CreateChessValidator()
        => new ChessValidator();

    private IChessFactory CreateChessFactory() => new ChessFactory();
}
