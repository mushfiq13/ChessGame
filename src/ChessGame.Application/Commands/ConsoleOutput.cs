using ChessGame.ConsoleUI;
using ChessGame.Domain;

namespace ChessGame.Application;

internal class ConsoleOutput : IConsoleOutput
{
    IConsoleManager _consoleManager = Factory.CreateConsoleManager();

    public void DrawUI(string currentPlayer,
        IChessCore[]? whiteCaptured,
        IChessCore[]? blackCaptured)
    {
        _consoleManager.Output
            .PrintLogo()
            .DrawBoard(Singleton.BoardManager.Tiles)
            .PrintWhiteCapturedItems(whiteCaptured)
            .PrintBlackCapturedItems(blackCaptured)
            .CurrentTurn(currentPlayer);

        // This should be added in next.
        // _consoleManager.Output.PrintMenu();
    }

    public void ResetConsole() => _consoleManager.Output.ResetConsole();
}
