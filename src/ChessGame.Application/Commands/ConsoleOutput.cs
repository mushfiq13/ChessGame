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
            .DrawBoard(Singleton.ChessBoard.Tiles)
            .PrintCapturedItems(whiteCaptured, "WHITE")
            .PrintCapturedItems(blackCaptured, "BLACK")
            .CurrentTurn(currentPlayer);

        // This should be added in next.
        // _consoleManager.Output.PrintMenu();
    }

    public void ResetConsole() => _consoleManager.Output.ResetConsole();
}
