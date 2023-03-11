namespace ChessGame.Domain;

public class Rook : Chess
{
    public Rook(ChessColor color, string unicode, int rank, int file)
        : base(color, unicode, rank, file)
    {
    }

    public override bool IsMoveable(IChessCore[,] tiles, (int rank, int file) destination)
    {
        var toXDirection = new[] { +1, +0, -1, +0 };
        var toYDirection = new[] { +0, +1, +0, -1 };

        return ChessPathValidator.FindChessCanMeetTarget(tiles, this, (Rank, File),
            toXDirection, toYDirection);
    }
}
