using ChessGame.Domain;

namespace ChessGame.Application;

internal interface IGenerateChess
{
    void CreateChessSet(ChessColor color);
}