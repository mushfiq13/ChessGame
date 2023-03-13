using ChessGame.Domain;

namespace ChessGame.Application;

internal interface IOutputHandler
{
    void DisplayOutput(ChessColor movingColor,
        IChess[,] tiles,
        IChess[] Captured);
}