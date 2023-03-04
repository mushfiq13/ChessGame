namespace ChessGame.Domain;

public class BlackPawn : ChessPiece
{
    public override ChessPieceColor Color => ChessPieceColor.Black;
    public override string Unicode => ChessConstants.BLACK_PAWNS_UNICODE;

    public BlackPawn(int pawnPositionInFile)
       : base(ChessConstants.BLACK_PAWNS_RANK, pawnPositionInFile)
    { }

    public override bool CanMove(in IChessPiece[,] board, int destRank, int destFile)
    {
        if (IsAlive == false || IsDestinationTileValid(destRank, destFile) == false)
            return false;

        var canMoveOneStepForward = destRank - 1 >= 0
            && board[destRank - 1, destFile] is null;
        // Can go if it is at initial state
        var canMoveTwoStepForward = Position.Rank == ChessConstants.BLACK_PAWNS_RANK
            && destRank - 2 >= 0
            && board[destRank - 1, destFile] is null
            && board[destRank - 2, destFile] is null;
        // Can go if killing is possible
        var canMoveOneStepForwardToDiagonal = board[destRank, destFile]?.Color == ChessPieceColor.White;

        return canMoveOneStepForward
            || canMoveTwoStepForward
            || canMoveOneStepForwardToDiagonal;
    }

    private bool IsDestinationTileValid(int destRank, int destFile)
    {
        // Checking Diagonal
        if (Position.Rank - destRank == 1
            && Math.Abs(destFile - Position.File) == 1)
            return true;

        // Checking Forward
        return Position.File == destFile
            && (Position.Rank - destRank == 1 || Position.Rank - destRank == 2);
    }
}
