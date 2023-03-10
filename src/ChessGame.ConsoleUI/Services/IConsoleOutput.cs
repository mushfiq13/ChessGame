namespace ChessGame.ConsoleUI;

public interface IConsoleOutput
{
    IConsoleOutput PrintLogo();
    IConsoleOutput PrintMenu();
    IConsoleOutput DrawBoard(in object[,] tiles);
    IConsoleOutput PrintWhiteCapturedItems(object[] whiteCaptured);
    IConsoleOutput PrintBlackCapturedItems(object[] blackCaptured);
    IConsoleOutput CurrentTurn(object value);
    void ResetConsole();
}