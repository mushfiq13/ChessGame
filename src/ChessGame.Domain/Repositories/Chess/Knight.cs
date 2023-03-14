namespace ChessGame.Domain;

internal class Knight : Chess
{
    public Knight(ChessColor color, string unicode, int rank, int file)
        : base(color, unicode, rank, file)
    {
    }

    public override bool CanMove(IChess[,] tiles, (int rank, int file) targetTile)
    {
        // Knight can go only to these directions.
        var xDir = new[] { +2, +1, -1, -2, -2, -1, +1, +2 };
        var yDir = new[] { +1, +2, +2, +1, -1, -2, -2, -1 };

        return _chessValidator.canSourceChessMoveToTargetTile(tiles,
            this,
            targetTile,
            xDir,
            yDir,
            1);
    }
}
