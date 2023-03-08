namespace ChessGame.Domain;

public class King : Chess
{
    public King(ChessColor color, string unicode, int rank, int file)
        : base(color, unicode, rank, file)
    {
    }

    public override bool IsMoveable(in IChessCore[,] tiles, int targetRank, int targetFile)
    {
        // King can go only to these directions.
        var xAxis = new[] { +1, +1, +0, -1, -1, -1, +0, +1 };
        var yAxis = new[] { +0, +1, +1, +1, +0, -1, -1, -1 };

        return IsKilled == false && ChessQuery.FindChessCanMeetTarget(tiles, (Rank, File),
            (targetRank, targetFile), xAxis, yAxis);
    }
}
