using ChessGame.Domain;

namespace ChessGame.Application;

internal interface IChessQueries
{
    bool IsKing(IChess chess);
}