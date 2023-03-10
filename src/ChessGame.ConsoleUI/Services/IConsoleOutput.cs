namespace ChessGame.ConsoleUI;

public interface IConsoleOutput
{
    IConsoleOutput PrintLogo();
    IConsoleOutput PrintMenu();
    IConsoleOutput DrawBoard(in object[,] tiles);
    IConsoleOutput PrintCapturedItems(object[] items, string chessType);
    IConsoleOutput CurrentTurn(object value);
    void ResetConsole();
}