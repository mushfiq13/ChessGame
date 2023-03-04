namespace ChessGame.Domain;

public class BlackRook : Rook
{
    public override ChessPieceColor Color => ChessPieceColor.Black;

    public override string Unicode => ChessConstants.BLACK_ROOK_UNICODE;

    public BlackRook(int file)
        : base(ChessConstants.BLACK_KING_RANK, file)
    {
    }
}
