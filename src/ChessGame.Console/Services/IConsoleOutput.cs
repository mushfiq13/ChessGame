namespace ChessGame.ConsoleUI;

public interface IConsoleOutput
{
    void WriteMessage(string text);
    void ResetConsole();
    void DrawBoard(in object[,] tiles);
}