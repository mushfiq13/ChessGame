namespace ChessGame.Domain;

public class RookModel : ChessPiece
{
    public RookModel(ChessPieceColor color, int rank, int file)
        : base(ChessPieceType.Rook, color, (rank, file))
    {
    }
}
