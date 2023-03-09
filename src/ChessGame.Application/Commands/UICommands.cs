using ChessGame.ConsoleUI;
using ChessGame.Domain;

namespace ChessGame.Application;

internal class UICommands : IUICommands
{
    IConsoleManager _consoleManager = Factory.CreateConsoleManager();

    public void WriteMessage(string message) => _consoleManager.Messager.Message(message);

    public void InvalidDataCapture()
        => _consoleManager.Messager.InvalidDataCapture();

    public (int rank, int file) CaptureChess()
        => _consoleManager.Input.SelectMoveableChess();

    public void DrawLogo() => _consoleManager.Output.PrintLogo();

    public void DisplayMenu() => _consoleManager.Output.PrintMenu();

    public void DisplayCapturedItems(IChessCore[] _whiteCaptured, IChessCore[] _blackCaptured)
        => _consoleManager.Output.PrintCapturedItems(_whiteCaptured, _blackCaptured);

    public void DrawTiles(in IChessCore[,] tiles)
        => _consoleManager.Output.DrawBoard(tiles);

    public void DisplayCurrentTurn(object obj) => _consoleManager.Output.CurrentTurn(obj);

    public void ResetConsole() => _consoleManager.Output.ResetConsole();

    public void DrawUI(IChessCore[,] tiles,
        string currentTurner,
        IChessCore[] whiteCaptured,
        IChessCore[] blackCaptured)
    {
        DrawLogo();
        DrawTiles(tiles);
        DisplayCapturedItems(whiteCaptured, blackCaptured);
        DisplayCurrentTurn(currentTurner);
    }
}
