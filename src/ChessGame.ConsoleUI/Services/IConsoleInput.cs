namespace ChessGame.ConsoleUI;

public interface IConsoleInput
{
    (int Rank, int File) SelectMoveableChess();
}