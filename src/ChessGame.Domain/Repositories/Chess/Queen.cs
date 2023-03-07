namespace ChessGame.Domain;

public class Queen : Chess
{
    public Queen(ChessColor color, string unicode, int rank, int file)
        : base(color, unicode, rank, file)
    {
    }

    public override bool IsMoveable(in IChessCore[,] tiles, int targetRank, int targetFile)
    {
        // Queen can go only to these directions.
        var xAxis = new[] { +1, +1, +0, -1, -1, -1, +0 };
        var yAxis = new[] { +0, +1, +1, +1, +0, -1, -1 };

        return IsDead is false && ChessQuery.FindChessCanMeetTarget(tiles, (Rank, File),
             (targetRank, targetFile), xAxis, yAxis);
    }
}
