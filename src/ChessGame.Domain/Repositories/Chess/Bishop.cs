namespace ChessGame.Domain;

public class Bishop : Chess
{
    public Bishop(ChessColor color, string unicode, int rank, int file)
        : base(color, unicode, rank, file)
    {
    }

    public override bool IsMoveable(in IChess[,] tiles, int targetRank, int targetFile)
    {
        // Bishop can go only to these directoins.
        var xAxis = new[] { +1, +1, -1, -1 };
        var yAxis = new[] { +1, -1, +1, -1 };

        return IsDead is false && ChessQuery.FindChessCanMeetTarget(tiles, (Rank, File),
            (targetRank, targetFile), xAxis, yAxis);
    }
}
