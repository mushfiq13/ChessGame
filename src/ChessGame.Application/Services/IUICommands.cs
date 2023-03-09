using ChessGame.Domain;

namespace ChessGame.Application;

internal interface IUICommands
{
    (int rank, int file) CaptureChess();

    void WriteMessage(string message);
    void InvalidDataCapture();

    void DrawLogo();
    void DisplayMenu();
    void DisplayCapturedItems(IChessCore[] _whiteCaptured, IChessCore[] _blackCaptured);
    void DrawTiles(in IChessCore[,] tiles);
    void DisplayCurrentTurn(object obj);

    void ResetConsole();

    void DrawUI(IChessCore[,] tiles,
        string currentTurner,
        IChessCore[] whiteCaptured,
        IChessCore[] blackCaptured);
}