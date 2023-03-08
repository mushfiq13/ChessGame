using ChessGame.Domain;

namespace ChessGame.Application;

internal interface IConsoleUICommands
{
    void DisplayMessage(string message);

    (int rank, int file) CaptureSourceTile();
    (int rank, int file) CaptureTargetTile();

    void DrawLogo();
    void DisplayMenu();
    void DisplayCapturedItems(IChessCore[] _whiteCaptured, IChessCore[] _blackCaptured);
    void DrawTiles(in IChessCore[,] tiles);
    void CurrentTurn(object obj);

    void ResetConsole();
}