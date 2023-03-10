namespace ChessGame.Application;

internal interface IConsoleInput
{
    object CaptureTile();
    string ReadText();
}