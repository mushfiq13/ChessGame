namespace ChessGame.Domain;

public class Pawn : Chess
{
    (int, int) _initialPosition;

    public Pawn(ChessColor color, string unicode, int rank, int file)
        : base(color, unicode, rank, file)
    {
        _initialPosition = (rank, file);
    }

    public override bool IsMoveable(in IChessCore[,] tiles, int targetRank, int targetFile)
    {
        var (xAxis, yAxis) = GetWhichDirectionToMove();

        return ChessPathValidator.FindChessCanMeetTarget(tiles, this, (targetRank, targetFile),
            xAxis.ToArray(), yAxis.ToArray());
    }

    private (IList<int> X, IList<int> Y) GetWhichDirectionToMove()
    {
        // White Pawn can go only to these directions.
        IList<int> x = new List<int> { +1, +1, +1 }; // For white pawn
        IList<int> y = new List<int> { +0, +1, -1 }; // For white pawn

        if ((Rank, File) == _initialPosition)
        {
            x.Add(+2);  // For white pawn
            y.Add(+0);  // For white pawn
        }

        // For black pawn directions will be negative.
        for (var i = 0; i < x.Count && Color == ChessColor.Black; ++i)
        {
            x[i] *= -1;
            y[i] *= -1;
        }

        return (x, y);
    }
}
