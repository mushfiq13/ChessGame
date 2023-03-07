using ChessGame.Domain;

namespace ChessGame.Application;

internal class InputQueries : IInputQueries
{
    public bool IsFileAndRankValid(int rank, int file)
        => rank > -1 && rank < ChessConstants.RANKS
        && file > -1 && file < ChessConstants.FILES;
}
