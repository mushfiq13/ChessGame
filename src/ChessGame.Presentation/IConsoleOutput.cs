namespace ChessGame.Presentation;

public interface IConsoleOutput
{
    void DisplayWelcome();
    void ShowBoard(in object[,] tiles);
}