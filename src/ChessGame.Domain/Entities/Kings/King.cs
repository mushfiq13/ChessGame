namespace ChessGame.Domain;

public abstract class King : ChessPiece
{
    protected King(int rank, int file) : base(rank, file)
    {
    }

    public override bool CanMove(in IChessPiece[,] board, int targetRank, int targetFile)
    {
        var isTargetTileValid = Math.Abs(targetRank - Position.Rank) <= 1
            && Math.Abs(targetFile - Position.File) <= 1;

        if (isTargetTileValid && board[targetRank, targetFile]?.Color != Color)
            return true;

        return false;
    }
}
