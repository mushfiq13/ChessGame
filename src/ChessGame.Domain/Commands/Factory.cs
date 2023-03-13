namespace ChessGame.Domain;

internal class Factory : IFactory
{
    public IChessBoard GetChessBoard() => new ChessBoard();
    public IBoardGenerator GetBoardGenerator()
        => new BoardGenerator(CreateChessFactory());

    private IChessFactory CreateChessFactory() => new ChessFactory();
}
