namespace ChessGame.Domain;

internal interface IFactory
{
    IChessBoard GetChessBoard();
    IBoardGenerator GetBoardGenerator();
}