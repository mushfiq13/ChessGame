namespace ChessGame.Domain;

internal class Queen : Chess
{
    public Queen(ChessColor color, string unicode, int rank, int file)
        : base(color, unicode, rank, file)
    {
    }

    public override bool CanMove(IChessBase[,] tiles, (int rank, int file) targetTile)
    {
        // Queen can go only to these directions.
        var xDir = new[] { +1, +1, +0, -1, -1, -1, +0 };
        var yDir = new[] { +0, +1, +1, +1, +0, -1, -1 };

        return _chessValidator.canSourceChessMoveToTargetTile(tiles, this, targetTile,
            xDir, yDir);
    }
}
