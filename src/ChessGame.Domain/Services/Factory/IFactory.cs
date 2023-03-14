namespace ChessGame.Domain;

internal interface IFactory
{
    IChessBoard CreateChessBoard();
    IBoardSetup GetBoardSetup();
}