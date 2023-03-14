namespace ChessGame.Domain;

internal class BoardSetup : IBoardSetup
{
    private static readonly IBoardSetup _instance = new BoardSetup();
    private readonly IChessFactory _chessFactory = ChessFactory.GetChessFactory();

    private BoardSetup()
    {
    }

    public static IBoardSetup GetBoardSetup()
    {
        return _instance;
    }

    public void AddChesses(ref IChessBoard board)
    {
        PutChesses(ref board, _chessFactory.CreateKing());
        PutChesses(ref board, _chessFactory.CreateQueen());
        PutChesses(ref board, _chessFactory.CreateRook());
        PutChesses(ref board, _chessFactory.CreateBishop());
        PutChesses(ref board, _chessFactory.CreateKnight());
        PutChesses(ref board, _chessFactory.CreatePawn());
        PutChesses(ref board, _chessFactory.CreatePawn());
    }

    private void PutChesses(ref IChessBoard board, IChess[] chesses)
    {
        foreach (var chess in chesses)
        {
            board.Put(chess, chess.Rank, chess.File);
        }
    }
}
