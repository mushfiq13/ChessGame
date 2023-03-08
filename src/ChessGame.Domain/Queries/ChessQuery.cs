namespace ChessGame.Domain;

public partial class ChessQuery
{
    public static bool FindChessCanMeetTarget(in IChessCore[,] tiles, (int rank, int file) source,
       (int rank, int file) target, int[] xDirection, int[] yDirection)
    {
        var canGo = false;

        for (var i = 0; i < xDirection.Length && canGo == false; ++i)
        {
            canGo = FindChessCanMeetTarget(tiles, source,
                target, xDirection[i], yDirection[i]);
        }

        return canGo;
    }

    public static bool FindChessCanMeetTarget(in IChessCore[,] tiles, (int rank, int file) source,
       (int rank, int file) target, int xDirection, int yDirection)
    {
        // Source tile and Target tile can not be same.
        // So, starting from next tile.
        int curRank = source.rank + xDirection;
        var curFile = source.file + yDirection;

        while (IsRankAndFileValid(curRank, curFile))
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

    public static bool IsRankAndFileValid(int rank, int file)
       => rank > -1 && rank < ChessConstants.RANKS
            && file > -1 && file < ChessConstants.FILES;
}
