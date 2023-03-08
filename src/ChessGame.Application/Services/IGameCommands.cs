using ChessGame.Domain;

namespace ChessGame.Application;

internal interface IGameCommands
{
    bool Move(IBoardManager boardManager, IChess item, int targetRank, int targetFile);
}