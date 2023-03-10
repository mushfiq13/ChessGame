using ChessGame.Domain;

namespace ChessGame.Application;

internal interface IGenerateChess
{
    List<IChess> CreateChessSet(ChessColor color);
}