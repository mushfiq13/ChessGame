using ChessGame.Domain;

namespace ChessGame.Application;

internal interface IConsoleUICommands
{
    void DisplayMessage(string message);

    (int rank, int file) CaptureChess();

    void DrawLogo();
    void DisplayMenu();
    void DisplayCapturedItems(IChessCore[] _whiteCaptured, IChessCore[] _blackCaptured);
    void DrawTiles(in IChessCore[,] tiles);
    void DisplayCurrentTurn(object obj);

    void ResetConsole();
}