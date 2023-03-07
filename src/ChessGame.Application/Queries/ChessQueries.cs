using ChessGame.Domain;

namespace ChessGame.Application;

internal class ChessQueries : IChessQueries
{
    public bool IsKing(IChess chess)
    {
        return chess?.Unicode == "\u2654" || chess?.Unicode == "\u265A";
    }
}
