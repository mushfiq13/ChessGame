namespace ChessGame.ConsoleUI;

public interface IConsoleMessager
{
    void Message(string message);
    void IndexOutOfBound();
    void InvalidDataCapture();
    void EndApplication();
}