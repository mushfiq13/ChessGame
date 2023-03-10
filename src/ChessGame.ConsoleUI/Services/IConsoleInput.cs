namespace ChessGame.ConsoleUI;

public interface IConsoleInput
{
    object ReadTileLocation();
    string ReadText();
}