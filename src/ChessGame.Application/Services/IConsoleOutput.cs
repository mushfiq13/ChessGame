using ChessGame.Domain;

namespace ChessGame.Application;

internal interface IConsoleOutput
{
    void DisplayCapturedItems(IChessCore[] _whiteCaptured, IChessCore[] _blackCaptured);
    void DisplayCurrentTurn(object obj);
    void DisplayMenu();
    void DrawLogo();
    void DrawTiles();
    void DrawUI(string currentTurner, IChessCore[] whiteCaptured, IChessCore[] blackCaptured);
    void ResetConsole();
}