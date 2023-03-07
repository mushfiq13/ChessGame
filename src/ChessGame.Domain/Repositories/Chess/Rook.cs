namespace ChessGame.Domain;

public class Rook : Chess
{
    public Rook(ChessColor color, string unicode, int rank, int file)
        : base(color, unicode, rank, file)
    {
    }

    public override bool IsMoveable(in IChessBase[,] tiles, int targetRank, int targetFile)
    {
        // Find in which direction to go.
        var xAxis = Rank == targetRank ? +0
            : targetRank > Rank ? +1
            : -1;
        var yAxis = File == targetFile ? +0
            : targetFile > File ? +1
            : -1;

        return IsDead is false && ChessQuery.FindChessCanMeetTarget(tiles, (Rank, File),
            (targetRank, targetFile), xAxis, yAxis);
    }
}
