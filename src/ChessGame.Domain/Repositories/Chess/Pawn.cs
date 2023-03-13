namespace ChessGame.Domain;

internal class Pawn : Chess
{
    (int, int) _initialPosition;

    public Pawn(ChessColor color, string unicode, int rank, int file)
        : base(color, unicode, rank, file)
    {
        _initialPosition = (rank, file);
    }

    public override bool IsMoveable(IChessCore[,] tiles, (int rank, int file) targetTile)
    {
        int[] xDir;
        int[] yDir;

        if (Color == ChessColor.White)
            (xDir, yDir) = GetWhitePawnDirection();
        else
            (xDir, yDir) = GetBlackPawnDirection();

        for (var i = 0; i < xDir.Length; ++i)
        {
            var nextRank = Rank + xDir[i];
            var nextFile = File + yDir[i];

            if (nextRank == targetTile.rank
                && nextFile == targetTile.file
                && tiles[nextRank, nextFile]?.Color != Color)
                return true;
        }

        return false;
    }

    private (int[], int[]) GetWhitePawnDirection()
    {
        // White Pawn can go only to these directions.
        IList<int> x = new List<int> { +1, +1, +1 };
        IList<int> y = new List<int> { +0, +1, -1 };

        if ((Rank, File) == _initialPosition)
        {
            x.Add(+2);
            y.Add(+0);
        }

        return (x.ToArray(), y.ToArray());
    }

    private (int[], int[]) GetBlackPawnDirection()
    {
        // White Pawn can go only to these directions.
        IList<int> x = new List<int> { -1, -1, -1 };
        IList<int> y = new List<int> { +0, -1, +1 };

        if ((Rank, File) == _initialPosition)
        {
            x.Add(-2);
            y.Add(+0);
        }

        return (x.ToArray(), y.ToArray());
    }
}
