using ChessGame.ConsoleUI;

namespace ChessGame.Application;

internal class ConsoleInput : IConsoleInput
{
    internal IConsoleManager _consoleManager = Factory.CreateConsoleManager();

    public (int rank, int file) CaptureChess()
        => _consoleManager.Input.SelectMoveableChess();
}
