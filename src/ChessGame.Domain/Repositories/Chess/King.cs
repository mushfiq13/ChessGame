namespace ChessGame.Domain;

internal class King : Chess
{
    public King(ChessColor color, string unicode, int rank, int file)
        : base(color, unicode, rank, file)
    {
    }

    public override bool CanMove(IChessBase[,] tiles, (int rank, int file) targetTile)
    {
        // King can go only to these directions.
        var xDir = new[] { +1, +1, +0, -1, -1, -1, +0, +1 };
        var yDir = new[] { +0, +1, +1, +1, +0, -1, -1, -1 };

        return _chessValidator.canSourceChessMoveToTargetTile(tiles,
           this,
           targetTile,
           xDir,
           yDir,
           1);
    }
}
