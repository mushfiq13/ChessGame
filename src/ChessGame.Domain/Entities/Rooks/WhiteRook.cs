namespace ChessGame.Domain;

public class WhiteRook : Rook
{
    public override ChessPieceColor Color => ChessPieceColor.White;

    public override string Unicode => ChessConstants.WHITE_ROOK_UNICODE;

    public WhiteRook(int file)
        : base(ChessConstants.WHITE_KING_RANK, file)
    {
    }
}
