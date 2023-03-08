using ChessGame.ConsoleUI;
using ChessGame.Domain;

namespace ChessGame.Application;

internal class ConsoleUICommands : IConsoleUICommands
{
    IConsoleManager _consoleManager = Factory.CreateConsoleManager();

    public void DisplayMessage(string message) => _consoleManager.Messager.Message(message);

    public (int rank, int file) CaptureSourceTile()
        => _consoleManager.Input.ReadTilePosition("Please select a chess to move...");

    public (int rank, int file) CaptureTargetTile()
        => _consoleManager.Input.ReadTilePosition("Please choose a target tile...");

    public void DrawLogo() => _consoleManager.Output.PrintLogo();

    public void DisplayMenu() => _consoleManager.Output.PrintMenu();

    public void DisplayCapturedItems(IChessCore[] _whiteCaptured, IChessCore[] _blackCaptured)
        => _consoleManager.Output.PrintCapturedItems(_whiteCaptured, _blackCaptured);

    public void DrawTiles(in IChessCore[,] tiles)
        => _consoleManager.Output.DrawBoard(tiles);

    public void CurrentTurn(object obj) => _consoleManager.Output.CurrentTurn(obj);

    public void ResetConsole() => _consoleManager.Output.ResetConsole();
}
