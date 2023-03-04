namespace ChessGame.Domain;

public abstract class Knight : ChessPiece
{
    protected Knight(int rank, int file) : base(rank, file)
    {
    }

    public override bool CanMove(in IChessPiece[,] board, int targetRank, int targetFile)
    {
        var xAxis = new[] { +2, +1, -1, -2, -2, -1, +1, +2 };
        var yAxis = new[] { +1, +2, +2, +1, -1, -2, -2, -1 };

        for (var i = 0; i < xAxis.Length; ++i)
        {
            if (Position.Rank + xAxis[i] == targetRank && Position.File + yAxis[i] == targetFile)
                return board[targetRank, targetFile]?.Color != Color;
        }

        return false;
    }
}
