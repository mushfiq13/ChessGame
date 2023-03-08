using ChessGame.ConsoleUI;
using ChessGame.Domain;

namespace ChessGame.Application;

internal class ConsoleUICommands : IConsoleUICommands
{
    IConsoleInput _consoleInput = Factory.CreateConsoleInput();
    IConsoleOutput _consoleOutput = Factory.CreateConsoleOutput();

    public (int rank, int file) CaptureSourceTile()
        => _consoleInput.ReadTilePosition("Please select a chess to move...");

    public (int rank, int file) CaptureTargetTile()
        => _consoleInput.ReadTilePosition("Please choose a target tile...");

    public void DrawTiles(in IChessCore[,] tiles)
        => _consoleOutput.DrawBoard(tiles);

    public void ResetConsole() => _consoleOutput.ResetConsole();
}
