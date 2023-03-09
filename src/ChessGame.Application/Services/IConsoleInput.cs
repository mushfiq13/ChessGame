namespace ChessGame.Application;

internal interface IConsoleInput
{
    (int rank, int file) CaptureChess();
}