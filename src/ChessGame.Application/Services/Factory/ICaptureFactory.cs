namespace ChessGame.Application;

internal interface ICaptureFactory
{
    ICaptureProcessor CreateCaptureProcessor();
}