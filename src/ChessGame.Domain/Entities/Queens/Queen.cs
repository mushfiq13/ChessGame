namespace ChessGame.Domain;

public abstract class Queen : ChessPiece
{
    protected Queen(int rank, int file)
        : base(rank, file)
    { }

    public override bool CanMove(in IChessPiece[,] board, int targetRank, int targetFile)
    {
        var xAxis = new[] { +1, +1, +0, -1, -1, -1, +0 };
        var yAxis = new[] { +0, +1, +1, +1, +0, -1, -1 };

        for (var i = 0; i < xAxis.Length; ++i)
        {
            if (IsPathValid(board, targetRank, targetFile, xAxis[i], yAxis[i]))
                return true;
        }

        return false;
    }

    private bool IsPathValid(in IChessPiece[,] board, int targetRank, int targetFile, int xAxis, int yAxis)
    {
        // starting from next tile.
        var rank = (int)Position.Rank + xAxis;
        var file = (int)Position.File + yAxis;

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
