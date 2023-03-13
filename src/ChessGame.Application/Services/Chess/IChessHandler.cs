using ChessGame.Domain;

namespace ChessGame.Application;

internal interface IChessHandler
{
    IChess HandleCurrentTurn(IChess sourceChess, int newRank, int newFile);
}