using ChessGame.ConsoleUI;

namespace ChessGame.Application;

internal class ConsoleInput : IConsoleInput
{
    internal IConsoleManager _consoleManager = Factory.CreateConsoleManager();

    public object CaptureTile()
        => _consoleManager.Input.ReadTileLocation();
}
