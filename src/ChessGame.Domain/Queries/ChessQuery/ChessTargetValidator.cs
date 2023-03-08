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
        (int rank, int file) new_move = (source.rank + xDirection, source.file + yDirection);

        if (Inbounds(new_move.rank, new_move.file) == false) return false;
        if (tiles[source.rank, source.file]?.Color == tiles[new_move.rank, new_move.file]?.Color)
            return false;
        if (new_move == target)
            return true;

        return FindChessCanMeetTarget(tiles, new_move, target, xDirection, yDirection);
    }

    public static bool Inbounds(int rank, int file)
       => rank > -1 && rank < ChessConstants.RANKS
            && file > -1 && file < ChessConstants.FILES;
}
