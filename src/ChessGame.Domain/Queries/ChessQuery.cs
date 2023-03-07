namespace ChessGame.Domain;

internal class ChessQuery
{
    public static bool CanChessMoveTarget(in IChess[,] tiles, (int rank, int file) source,
       (int rank, int file) target, int[] xDirection, int[] yDirection)
    {
        var validPath = false;

        for (var i = 0; i < xDirection.Length && validPath == false; ++i)
        {
            validPath = CanChessMoveTarget(tiles, source,
                target, xDirection[i], yDirection[i]);
        }

        return validPath;
    }

    public static bool CanChessMoveTarget(in IChess[,] tiles, (int rank, int file) source,
       (int rank, int file) target, int xDirection, int yDirection)
    {
        // Source tile and Target tile can not be same.
        // So, starting from next tile.
        int curRank = source.rank + xDirection;
        var curFile = source.file + yDirection;

        while (curRank > -1 && curRank < ChessConstants.RANKS
            && curFile > -1 && curFile < ChessConstants.FILES)
        {
            if (tiles[source.rank, source.file]?.Color == tiles[curRank, curFile]?.Color)
                return false;
            if (curRank == target.rank && curFile == target.file)
                return true;

            curRank += xDirection;
            curFile += yDirection;
        }

        return false;
    }

    public static bool IsChessLocationValid(IChess item)
       => item.Rank > -1 && item.File > -1
           && item.Rank < ChessConstants.RANKS && item.File < ChessConstants.FILES;
}
