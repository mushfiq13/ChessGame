namespace ChessGame.ConsoleUI;

public interface IConsoleOutput
{
    void Write(string text);
    IConsoleOutput PrintLogo();
    IConsoleOutput PrintMenu();
    IConsoleOutput DrawBoard(in object[,] tiles);
    IConsoleOutput PrintCapturedItems(object[] items, string chessType);
    IConsoleOutput CurrentTurn(object value);
    void ResetConsole();
}