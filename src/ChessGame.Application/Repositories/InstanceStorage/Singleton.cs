using ChessGame.ConsoleUI;
using ChessGame.Domain;

namespace ChessGame.Application;

internal class Singleton : IDisposable
{
    internal static IBoardManager BoardManager = Factory.CreateBoardManager();
    internal static IConsoleManager ConsoleManager = Factory.CreateConsoleManager();
    internal static IConsoleInput ConsoleInput = Factory.CreateConsoleInput();
    internal static IConsoleOutput ConsoleOutput = Factory.CreateConsoleOutput();
    internal static IConsoleMessages ConsoleMessages = Factory.CreateConsoleMessages();

    public void Dispose()
    {
        BoardManager = null;
        ConsoleManager = null;
        ConsoleInput = null;
        ConsoleOutput = null;
        ConsoleMessages = null;
    }
}
