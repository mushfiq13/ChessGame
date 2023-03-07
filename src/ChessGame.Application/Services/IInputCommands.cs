namespace ChessGame.Application;

internal interface IInputCommands
{
    (int rank, int file) CaptureSourceTile();
    (int rank, int file) CaptureTargetTile();
}
