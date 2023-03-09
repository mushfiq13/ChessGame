using ChessGame.Domain;

namespace ChessGame.Application;

internal class ConsoleOutput : IConsoleOutput
{
    public void DrawLogo() => Singleton.ConsoleManager.Output.PrintLogo();

    public void DisplayMenu() => Singleton.ConsoleManager.Output.PrintMenu();

    public void DisplayCapturedItems(IChessCore[] _whiteCaptured, IChessCore[] _blackCaptured)
        => Singleton.ConsoleManager.Output
            .PrintCapturedItems(_whiteCaptured, _blackCaptured);

    public void DrawTiles()
        => Singleton.ConsoleManager.Output
            .DrawBoard(Singleton.BoardManager.Tiles);

    public void DisplayCurrentTurn(object obj)
        => Singleton.ConsoleManager.Output.CurrentTurn(obj);

    public void DrawUI(string currentTurner,
        IChessCore[] whiteCaptured,
        IChessCore[] blackCaptured)
    {
        DrawLogo();
        DrawTiles();
        DisplayCapturedItems(whiteCaptured, blackCaptured);
        DisplayCurrentTurn(currentTurner);
    }

    public void ResetConsole() => Singleton.ConsoleManager.Output.ResetConsole();
}
