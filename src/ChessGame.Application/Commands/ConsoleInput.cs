namespace ChessGame.Application;

internal class ConsoleInput : IConsoleInput
{
    public (int rank, int file) CaptureChess()
        => Singleton.ConsoleManager.Input.SelectMoveableChess();
}
