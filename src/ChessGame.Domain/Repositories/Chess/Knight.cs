namespace ChessGame.Domain;

internal class Knight : Chess
{
    public Knight(ChessColor color, string unicode, int rank, int file)
        : base(color, unicode, rank, file)
    {
    }

    public override bool IsMoveable(IChessCore[,] tiles, (int rank, int file) targetTile)
    {
        // Knight can go only to these directions.
        var xDir = new[] { +2, +1, -1, -2, -2, -1, +1, +2 };
        var yDir = new[] { +1, +2, +2, +1, -1, -2, -2, -1 };

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
