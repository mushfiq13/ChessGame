namespace ChessGame.Domain;

internal interface IFactory
{
    IChessBoard CreateChessBoard();
    IBoardGenerator CreateBoardGenerator();
    IChessValidator CreateChessValidator();
}