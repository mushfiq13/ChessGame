namespace ChessGame.Domain;

internal class King : Chess
{
    public King(ChessColor color, string unicode, int rank, int file)
        : base(color, unicode, rank, file)
    {
    }

    public override bool IsMoveable(IChessCore[,] tiles, (int rank, int file) targetTile)
    {
        // King can go only to these directions.
        var xDir = new[] { +1, +1, +0, -1, -1, -1, +0, +1 };
        var yDir = new[] { +0, +1, +1, +1, +0, -1, -1, -1 };

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
}
