namespace ChessGame.Domain;

public class BishopModel : ChessPiece
{
    public BishopModel(ChessPieceColor color, int rank, int file)
        : base(ChessPieceType.Bishop, color, (rank, file))
    {
    }
}
