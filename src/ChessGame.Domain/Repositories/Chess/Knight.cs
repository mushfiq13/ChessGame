namespace ChessGame.Domain;

public class Knight : Chess
{
    public Knight(ChessColor color, string unicode, int rank, int file)
        : base(color, unicode, rank, file)
    {
    }

    public override bool IsMoveable(IChessCore[,] tiles, (int rank, int file) destination)
    {
        // Knight can go only to these directions.
        var xDir = new[] { +2, +1, -1, -2, -2, -1, +1, +2 };
        var yDir = new[] { +1, +2, +2, +1, -1, -2, -2, -1 };

        return ChessPathValidator.FindChessCanMeetTarget(tiles, this,
             destination, xDir, yDir);
    }
}
