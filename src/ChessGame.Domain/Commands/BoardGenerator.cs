namespace ChessGame.Domain;

internal class BoardGenerator : IBoardGenerator
{
    IChessFactory _chessFactory;

    public BoardGenerator(IChessFactory chessFactory)
    {
        _chessFactory = chessFactory;
    }

    public void InitializeBoard(IChessBoard board)
    {
        board.Add(_chessFactory.CreateKing())
            .Add(_chessFactory.CreateQueen())
            .Add(_chessFactory.CreateRook())
            .Add(_chessFactory.CreateBishop())
            .Add(_chessFactory.CreateKnight())
            .Add(_chessFactory.CreatePawn());
    }
}
