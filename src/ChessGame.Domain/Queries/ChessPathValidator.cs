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
                sourceChess?.Color,
                currentTile: (sourceChess.Rank, sourceChess.File),
                targetTile,
                xDir[i],
                yDir[i]))
                return true;
        }

        return false;
    }

    public static bool FindChessCanMeetTarget(IChessCore[,] tiles,
        ChessColor? restrictedColor,
        (int rank, int file) currentTile,
        (int rank, int file) targetTile,
        int xDir,
        int yDir)
    {
        (int rank, int file) nextMove = (currentTile.rank + xDir, currentTile.file + yDir);

        if (Inbounds(nextMove.rank, nextMove.file) == false
            || restrictedColor == tiles[nextMove.rank, nextMove.file]?.Color) // same type of chess appears
            return false;

        if (nextMove == targetTile)
            return true; // Found, source and target are not same

        if (tiles[nextMove.rank, nextMove.file] is not null)
            return false; // source and target are not same. But source can not go through to this chess

        return FindChessCanMeetTarget(tiles, restrictedColor, nextMove, targetTile, xDir, yDir);
    }

    public static bool Inbounds(int rank, int file)
       => rank > -1 && rank < ChessConstants.RANKS
            && file > -1 && file < ChessConstants.FILES;
}
