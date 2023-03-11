namespace ChessGame.Domain;

public class Bishop : Chess
{
    public Bishop(ChessColor color, string unicode, int rank, int file)
        : base(color, unicode, rank, file)
    {
    }

    public override bool IsMoveable(IChessCore[,] tiles, (int rank, int file) destination)
    {
        // Bishop can go only to these directoins.
        var xDir = new[] { +1, +1, -1, -1 };
        var yDir = new[] { +1, -1, +1, -1 };

        return ChessPathValidator.FindChessCanMeetTarget(tiles, this,
            destination, xDir, yDir);
    }
}
