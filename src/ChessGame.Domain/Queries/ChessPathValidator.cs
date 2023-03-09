namespace ChessGame.Domain;

internal class ChessPathValidator
{
    public static bool FindChessCanMeetTarget(in IChessCore[,] tiles, IChessCore source,
       (int rank, int file) target, int[] xDirection, int[] yDirection)
    {
        var canGo = false;

        for (var i = 0; i < xDirection.Length && canGo == false; ++i)
        {
            canGo = FindChessCanMeetTarget(tiles, source,
                (source.Rank, source.File), target, xDirection[i], yDirection[i]);
        }

        return canGo;
    }

    public static bool FindChessCanMeetTarget(in IChessCore[,] tiles, IChessCore source,
        (int rank, int file) current, (int rank, int file) target, int xDirection, int yDirection)
    {
        (int rank, int file) new_move = (current.rank + xDirection, current.file + yDirection);

        if (Inbounds(new_move.rank, new_move.file) == false)
            return false;
        if (tiles[source.Rank, source.File]?.Color == tiles[new_move.rank, new_move.file]?.Color)
            return false; // same type of chess appears
        if (new_move == (target.rank, target.file))
            return true; // Found, Both are not same
        if (tiles[new_move.rank, new_move.file] is not null)
            return false; // Both are not same. But source can not go through to this chess

        return FindChessCanMeetTarget(tiles, source, new_move, target, xDirection, yDirection);
    }

    public static bool Inbounds(int rank, int file)
       => rank > -1 && rank < ChessConstants.RANKS
            && file > -1 && file < ChessConstants.FILES;
}
