using ChessGame.Domain;

namespace ChessGame.Application;

internal interface IChessSetCreator
{
    List<IChess> Create(ChessColor color);
}