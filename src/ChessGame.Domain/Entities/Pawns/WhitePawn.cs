namespace ChessGame.Domain;

public class WhitePawn : ChessPiece
{
    public override ChessPieceColor Color => ChessPieceColor.White;
    public override string Unicode => ChessConstants.WHITE_PAWNS_UNICODE;

    public WhitePawn(int pawnPositionInFile)
        : base(ChessConstants.WHITE_PAWNS_RANK, pawnPositionInFile)
    { }

    public override bool CanMove(in IChessPiece[,] board, int targetRank, int targetFile)
    {
        if (IsAlive == false || IsDestinationTileValid(targetRank, targetFile) == false)
            return false;

        var canMoveOneStepForward = targetRank + 1 < ChessConstants.RANKS
            && board[targetRank + 1, targetFile] is null;
        // Can go if it is at initial state
        var canMoveTwoStepForward = Position.Rank == ChessConstants.WHITE_PAWNS_RANK
            && targetRank + 2 < ChessConstants.RANKS
            && board[targetRank + 1, targetFile] is null
            && board[targetRank + 2, targetFile] is null;
        // Can go if killing is possible
        var canMoveOneStepForwardToDiagonal = board[targetRank, targetFile]?.Color == ChessPieceColor.Black;

        return canMoveOneStepForward
            || canMoveTwoStepForward
            || canMoveOneStepForwardToDiagonal;
    }

    private bool IsDestinationTileValid(int targetRank, int targetFile)
    {
        // Checking Diagonal
        if (targetRank - Position.Rank == 1
            && Math.Abs(targetFile - (int)Position.File) == 1)
            return true;

        // Checking Forward
        return Position.File == targetFile
            && (targetRank - Position.Rank == 1 || targetRank - Position.Rank == 2);
    }
}
