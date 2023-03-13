namespace ChessGame.Domain;

internal interface IChessFactory
{
    IChess[] CreateBishop();
    IChess[] CreateKing();
    IChess[] CreateKnight();
    IChess[] CreatePawn();
    IChess[] CreateQueen();
    IChess[] CreateRook();
}