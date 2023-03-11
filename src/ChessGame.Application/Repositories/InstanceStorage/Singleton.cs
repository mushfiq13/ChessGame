using ChessGame.ConsoleUI;
using ChessGame.Domain;

namespace ChessGame.Application;

internal class Singleton
{
    internal readonly static ILogger Logger = Factory.CreateLogger();
    internal readonly static IConsoleIOManager IO = Factory.CreateConsoleIOManager();

    internal readonly static IChessBoard ChessBoard = Factory.CreateChessBoard();

    internal readonly static ICapturer Capturer = Factory.CreateCapturer();
    internal readonly static ICaptureProcessor CaptureProcessor = Factory.CreateCaptureProcessor();
    internal readonly static ICaptureValidator CaptureValidator = Factory.CreateCaptureValidator();
}
