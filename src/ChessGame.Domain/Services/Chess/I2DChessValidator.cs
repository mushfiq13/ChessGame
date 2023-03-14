namespace ChessGame.Domain;

internal interface I2DChessValidator
{
    bool canSourceChessMoveToTargetTile(IChess[,] tiles,
        IChess sourceChess,
        (int rank, int file) targetTile,
        int[] xDir, int[] yDir,
        int sourceChessCanJumpAtMost = int.MaxValue);

    bool Inbounds(int rank, int file);
}