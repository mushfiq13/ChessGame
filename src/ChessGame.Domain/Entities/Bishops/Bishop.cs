namespace ChessGame.Domain;

public abstract class Bishop : ChessPiece
{
    protected Bishop(int rank, int file) : base(rank, file)
    {
    }

    public override bool CanMove(in IChessPiece[,] board, int targetRank, int targetFile)
    {
        var xAxis = new[] { +1, +1, -1, -1 };
        var yAxis = new[] { +1, -1, +1, -1 };

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
