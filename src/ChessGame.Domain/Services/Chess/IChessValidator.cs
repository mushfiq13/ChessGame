namespace ChessGame.Domain;

internal interface IChessValidator
{
    bool canSourceChessMoveToTargetTile(IChess[,] tiles,
        IChess sourceChess,
        (int rank, int file) targetTile,
        int[] xDir, int[] yDir,
        int chessCanJumpAtMost = int.MaxValue);

    bool Inbounds(int rank, int file);
}