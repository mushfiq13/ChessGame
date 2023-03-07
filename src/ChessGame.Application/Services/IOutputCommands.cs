using ChessGame.Domain;

namespace ChessGame.Application;

internal interface IOutputCommands
{
    void WriteMessage(string message);
    void DrawTiles(in IChess[,] tiles);
}
