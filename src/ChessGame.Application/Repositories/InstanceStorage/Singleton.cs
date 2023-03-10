using ChessGame.Domain;

namespace ChessGame.Application;

internal class Singleton
{
    internal readonly static IChessBoard ChessBoard = Factory.CreateChessBoard();
    internal readonly static IConsoleInput ConsoleInput = Factory.CreateConsoleInput();
    internal readonly static IConsoleOutput ConsoleOutput = Factory.CreateConsoleOutput();
    internal readonly static IConsoleMessages ConsoleMessages = Factory.CreateConsoleMessages();
}
