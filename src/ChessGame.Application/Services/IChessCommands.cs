using ChessGame.Domain;

namespace ChessGame.Application;

internal interface IChessCommands
{
    bool Move(IBoardManager boardManager, IChess item, int targetRank, int targetFile);
}