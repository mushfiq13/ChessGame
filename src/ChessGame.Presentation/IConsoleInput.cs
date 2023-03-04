namespace ChessGame.Presentation;

public interface IConsoleInput
{
    (int Rank, int File) ReadTilePosition(string selectionMessage);
}