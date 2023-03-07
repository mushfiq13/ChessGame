namespace ChessGame.ConsoleUI;

public interface IConsoleOutput
{
    void WriteMessage(string text);
    void DrawBoard(in object[,] tiles);
}