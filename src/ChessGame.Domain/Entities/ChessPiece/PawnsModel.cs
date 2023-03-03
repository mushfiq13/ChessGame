namespace ChessGame.Domain;

public class PawnsModel : ChessPiece
{
    private bool _IsAtInitialPosition = true;

    public PawnsModel(ChessPieceColor color, int rank, int file)
        : base(ChessPieceType.Pawns, color, (rank, file))
    {
    }

    public bool Move(in IChessPiece[,] tiles, int destRank, int destFile)
    {
        var rankDistance = destRank - Position.Rank;
        var fileDistance = destFile - Position.File;

        if ((rankDistance == 1 && fileDistance == 1)
            || (rankDistance == 2 && fileDistance == 0))
        {
            return true;
        }

        return false;
    }
}
