namespace ChessGame.Domain;

public class BlackKing : King
{
    public override ChessPieceColor Color => ChessPieceColor.Black;
    public override string Unicode => ChessConstants.BLACK_KING_UNICODE;

    public BlackKing()
        : base(ChessConstants.BLACK_KING_RANK, ChessConstants.KING_POSITION_IN_FILE)
    { }
}
