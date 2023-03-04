using ChessGame.Presentation;

namespace ChessGame.Application;

internal class InputCommands : IInputCommands
{
    IConsoleInput _consoleInput;

    public InputCommands(IConsoleInput consoleInput)
    {
        _consoleInput = consoleInput;
    }

    public (int rank, int file) SelecteTile()
        => _consoleInput.ReadTilePosition("Please select a chess to move...");

    public (int rank, int file) ChoseTargetTile()
        => _consoleInput.ReadTilePosition("Please choose a target tile...");
}
