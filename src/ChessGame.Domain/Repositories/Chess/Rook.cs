namespace ChessGame.Domain;

internal class Rook : Chess
{
    public Rook(ChessColor color, string unicode, int rank, int file)
        : base(color, unicode, rank, file)
    {
    }

    public override bool CanMove(IChess[,] tiles, (int rank, int file) targetTile)
    {
        var xDir = new[] { +1, +0, -1, +0 };
        var yDir = new[] { +0, +1, +0, -1 };

        return _chessValidator.canSourceChessMoveToTargetTile(tiles, this, targetTile,
            xDir, yDir);
    }
}
