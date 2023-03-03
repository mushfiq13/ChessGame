namespace ChessGame.Domain;

public class QueenModel : ChessPiece
{
    public QueenModel(ChessPieceColor color, int rank, int file)
        : base(ChessPieceType.Queen, color, (rank, file))
    {
    }
}
