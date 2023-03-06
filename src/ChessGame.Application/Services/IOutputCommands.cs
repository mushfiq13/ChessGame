using ChessGame.Domain;

namespace ChessGame.Application;

internal interface IOutputCommands
{
    void DisplayWelcomeMessage();
    void DisplayTiles(in IChess[,] tiles);
}
