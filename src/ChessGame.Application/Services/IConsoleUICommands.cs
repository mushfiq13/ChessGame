using ChessGame.Domain;

namespace ChessGame.Application;

internal interface IConsoleUICommands
{
    (int rank, int file) CaptureSourceTile();
    (int rank, int file) CaptureTargetTile();
    void DrawTiles(in IChessCore[,] tiles);
    void ResetConsole();
}