namespace ChessGame.Domain;

public class Pawn : Chess
{
    int _initialRank;

    public Pawn(ChessColor color, string unicode, int rank, int file)
        : base(color, unicode, rank, file)
    {
        _initialRank = rank;
    }

    public override bool Move(in IChess[,] tiles, int targetRank, int targetFile)
    {
        var (xAxis, yAxis) = GetDirection();

        if (IsAlive && ChessQuery.CanChessMoveTarget(tiles, Rank, File,
            targetRank, targetFile, xAxis.ToArray(), yAxis.ToArray()))
        {
            ResetPosition(targetRank, targetFile);

            return true;
        }

        return false;
    }

    private (IList<int> X, IList<int> Y) GetDirection()
    {
        // White Pawn can go only to these directoins.
        IList<int> x = new List<int> { +1, +1, +1 }; // For white pawn
        IList<int> y = new List<int> { +0, +1, -1 }; // For white pawn

        if (Rank == _initialRank)
        {
            x.Add(+2);  // For white pawn
            y.Add(+0);  // For white pawn
        }

        for (var i = 0; i < x.Count && Color == ChessColor.Black; ++i)
        {
            // For black pawn directions will be negative.
            x[i] *= -1;
            y[i] *= -1;
        }

        return (x, y);
    }
}
