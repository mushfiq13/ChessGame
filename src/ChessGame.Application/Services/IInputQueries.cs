namespace ChessGame.Application;

internal interface IInputQueries
{
    bool IsFileAndRankValid(int rank, int file);
}
