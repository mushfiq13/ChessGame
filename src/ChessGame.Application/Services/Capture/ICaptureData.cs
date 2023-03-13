namespace ChessGame.Application;

internal interface ICaptureData
{
    (int, int) Capture();
}