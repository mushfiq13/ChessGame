namespace ChessGame.Domain;

public class WhiteQueen : Queen
{
    public override ChessPieceColor Color => ChessPieceColor.White;
    public override string Unicode => ChessConstants.WHITE_QUEEN_UNICODE;

    public WhiteQueen()
        : base(ChessConstants.WHITE_KING_RANK, ChessConstants.QUEEN_POSITION_IN_FILE)
    { }
}
