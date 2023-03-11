namespace ChessGame.Domain;

internal class ChessPathValidator
{
    public static bool FindChessCanMeetTarget(IChessCore[,] tiles,
        IChessCore sourceChess,
       (int rank, int file) targetTile,
       int[] xDir,
       int[] yDir)
    {
        for (var i = 0; i < xDir.Length; ++i)
        {
            if (FindChessCanMeetTarget(tiles,
                sourceChess,
                currentTile: (sourceChess.Rank, sourceChess.File),
                targetTile,
                xDir[i],
                yDir[i]))
                return true;
        }

        return false;
    }

    public static bool FindChessCanMeetTarget(IChessCore[,] tiles,
        IChessCore sourceChess,
        (int rank, int file) currentTile,
        (int rank, int file) targetTile,
        int xDir,
        int yDir)
    {
        (int rank, int file) newMove = (currentTile.rank + xDir, currentTile.file + yDir);

        if (Inbounds(newMove.rank, newMove.file) == false
            || sourceChess?.Color == tiles[newMove.rank, newMove.file]?.Color) // same type of chess appears
            return false;

        if (newMove == targetTile)
            return true; // Found, Both are not same

        if (tiles[newMove.rank, newMove.file] is not null)
            return false; // Both are not same. But source can not go through to this chess

        return FindChessCanMeetTarget(tiles, sourceChess, newMove, targetTile, xDir, yDir);
    }

    public static bool Inbounds(int rank, int file)
       => rank > -1 && rank < ChessConstants.RANKS
            && file > -1 && file < ChessConstants.FILES;
}
