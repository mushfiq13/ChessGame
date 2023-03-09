using ChessGame.Domain;

namespace ChessGame.Application;

internal interface IChessHandler
{
    void Kill(IChess item);
    bool Move(IChess item, int newRank, int newFile);
}