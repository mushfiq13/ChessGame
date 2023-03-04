namespace ChessGame.Domain;

public abstract class Rook : ChessPiece
{
    protected Rook(int rank, int file) : base(rank, file)
    {
    }

    public override bool CanMove(in IChessPiece[,] board, int targetRank, int targetFile)
    {
        // Find in which director to go.
        var xAxis = Position.Rank == targetRank ? +0
            : targetRank > Position.Rank ? +1
            : -1;
        var yAxis = Position.File == targetFile ? +0
            : targetFile > Position.File ? +1
            : -1;

        return IsPathValid(board, targetRank, targetFile, xAxis, yAxis);
    }

    private bool IsPathValid(in IChessPiece[,] board, int targetRank, int targetFile, int xAxis, int yAxis)
    {
        // starting from next tile.
        var rank = Position.Rank + xAxis;
        var file = Position.File + yAxis;

        while (rank > -1 && rank < ChessConstants.RANKS
            && file > -1 && file < ChessConstants.FILES)
        {
            if (rank == targetRank && file == targetFile
                && board[rank, file]?.Color != Color)
                return true;

            if (board[rank, file] is not null)
                return false;

            rank += xAxis;
            file += yAxis;
        }

        return false;
    }
}
