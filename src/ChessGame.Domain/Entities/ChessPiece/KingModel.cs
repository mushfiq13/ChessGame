namespace ChessGame.Domain;

public class KingModel : ChessPiece
{
    public KingModel(ChessPieceColor color, int rank, int file)
        : base(ChessPieceType.King, color, (rank, file))
    {
    }
}
