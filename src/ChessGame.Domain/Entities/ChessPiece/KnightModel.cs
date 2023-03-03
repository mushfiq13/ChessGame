namespace ChessGame.Domain;

public class KnightModel : ChessPiece
{
    public KnightModel(ChessPieceColor color, int rank, int file)
        : base(ChessPieceType.Knight, color, (rank, file))
    {
    }
}
