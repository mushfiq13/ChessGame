namespace ChessGame.ConsoleUI;

public interface IConsoleInput
{
    (int Rank, int File) ReadTilePosition(string selectionMessage);
}