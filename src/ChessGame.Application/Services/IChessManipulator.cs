using ChessGame.Domain;

namespace ChessGame.Application;

internal interface IChessManipulator
{
    void Kill(IBoardManager boardManager, IChess target);
    bool Move(IBoardManager boardManager, IChess source, int newRank, int newFile);
}