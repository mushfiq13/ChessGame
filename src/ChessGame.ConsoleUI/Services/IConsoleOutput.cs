namespace ChessGame.ConsoleUI;

public interface IConsoleOutput
{
    void PrintLogo();
    void PrintMenu();
    void DrawBoard(in object[,] tiles);
    void PrintCapturedItems(object[] whiteCaptured, object[] blackCaptured);
    void CurrentTurn(object value);
    void ResetConsole();
}