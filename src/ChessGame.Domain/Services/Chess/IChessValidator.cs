namespace ChessGame.Domain;

internal interface IChessValidator
{
    bool canSourceChessMoveToTargetTile(IChessBase[,] tiles,
        IChessBase sourceChess,
        (int rank, int file) targetTile,
        int[] xDir, int[] yDir,
        int chessCanJumpAtMost = int.MaxValue);

    bool Inbounds(int rank, int file);
}