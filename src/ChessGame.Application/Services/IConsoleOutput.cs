using ChessGame.Domain;

namespace ChessGame.Application;

internal interface IConsoleOutput
{
    void DrawUI(string currentPlayer, IChessCore[]? whiteCaptured, IChessCore[]? blackCaptured);
    void ResetConsole();
}