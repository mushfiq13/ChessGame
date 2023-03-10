namespace ChessGame.Application;

internal interface ICapturer
{
    (int, int) Capture();
}