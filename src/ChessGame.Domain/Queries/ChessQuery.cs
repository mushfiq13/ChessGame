namespace ChessGame.Domain;

internal class ChessQuery
{
    public static bool CanChessMoveTarget(in IChess[,] tiles, int sourceRank, int sourceFile,
        int targetRank, int targetFile, int[] xDirection, int[] yDirection)
    {
        var validPath = false;

        for (var i = 0; i < xDirection.Length && validPath == false; ++i)
        {
            validPath = CanChessMoveTarget(tiles, sourceRank, sourceFile,
                targetRank, targetFile, xDirection[i], yDirection[i]);
        }

        return validPath;
    }

    public static bool CanChessMoveTarget(in IChess[,] tiles, int sourceRank, int sourceFile,
        int targetRank, int targetFile, int xDirection, int yDirection)
    {
        // Source tile and Target tile can not be same.
        // So, starting from next tile.
        int curRank = sourceRank + xDirection;
        var curFile = sourceFile + yDirection;

        while (curRank > -1 && curRank < ChessConstants.RANKS
            && curFile > -1 && curFile < ChessConstants.FILES)
        {
            if (tiles[sourceRank, sourceFile]?.Color == tiles[curRank, curFile]?.Color)
                return false;
            if (curRank == targetRank && curFile == targetFile)
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
