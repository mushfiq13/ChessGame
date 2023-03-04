namespace ChessGame.Domain;

public class WhiteKing : King
{
    public override ChessPieceColor Color => ChessPieceColor.White;
    public override string Unicode => ChessConstants.WHITE_KING_UNICODE;

    public WhiteKing()
        : base(ChessConstants.WHITE_KING_RANK, ChessConstants.KING_POSITION_IN_FILE)
    { }
}
